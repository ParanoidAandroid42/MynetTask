﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Interface;
using Mynet.Manager;
using Mynet.Data;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class SkillController : MonoBehaviour
    {
        [Header("fire rate")]
        public float fireRate;
        [Header("fire speed")]
        public float fireSpeed;
        [Header("bullet spawn offset")]
        public float rateOffset = 2;
        [Header("bullet prefab")]
        public GameObject bulletPrefab;
        [Header("bullet spawn point")]
        public Transform firePoint;

        private IAttackInterface _attack;
        private List<Feature> _features;
        private Animator _animator;
        private bool _gameStart;

        public IAttackInterface Attack { get => _attack; set => _attack = value; }
        public List<Feature> Features { get => _features; set => _features = value; }

        public void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            InitConfigurations();
        }

        public void InitConfigurations()
        {
            InitEvents();
        }

        /// <summary>
        /// start game
        /// </summary>
        public void StartGame()
        {
            _features = new List<Feature>();
            _attack = new BaseRangeAttackController(bulletPrefab, fireSpeed, fireRate,rateOffset,0);
            _gameStart = true;
        }


        /// <summary>
        /// set copy features to clone object from original prefab
        /// </summary>
        /// <param name="featureControllers"></param>
        public void Clone(List<Feature> featureControllers,float currentTime)
        {
            _features = featureControllers;
            _attack = new BaseRangeAttackController(bulletPrefab, fireSpeed, fireRate, rateOffset, currentTime);
            for (int i = 0; i < _features.Count; i++)
            {
                AddFeature(_features[i]);
            }
            _gameStart = true;
        }

        public void Update()
        {
            if (_gameStart && _attack.IsAttacktimeUpdated(Time.deltaTime))
            {
                _attack.Fire(0, firePoint.transform.position);

                //I could have the character attack after the end of the Animation.but I did not want to create confusion while evaluating the project
                _animator.Play(Enum.AnimationType.Attack.ToString()); 
            }
        }

        public void InitEvents()
        {
            EventManager.Instance.StartListening(Enum.GameAction.OnFeatureButton.ToString(), OnFeatureButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
            EventManager.Instance.StartListening(Enum.StateAction.OnMenu.ToString(), OnMenu);
        }

        /// <summary>
        /// run when pressed featureButton
        /// </summary>
        /// <param name="arg"></param>
        public void OnFeatureButton(System.Object arg = null)
        {
            Feature skill = (Feature)arg;
            AddNewFeature(skill);
        }

        /// <summary>
        /// On Game configuration
        /// </summary>
        /// <param name="arg"></param>
        public void OnGame(System.Object arg = null)
        {
            StartGame();
        }

        /// <summary>
        /// On Menu configuration
        /// </summary>
        /// <param name="arg"></param>
        public void OnMenu(System.Object arg = null)
        {
            _gameStart = false;
        }

        /// <summary>
        /// add new feature according to pressed feature button
        /// </summary>
        /// <param name="feature"></param>
        public void AddNewFeature(Feature feature)
        {
            AddFeature(feature);
            _features.Add(feature);
            if (gameObject.tag == Enum.Tag.Player.ToString())
                CheckAdditionalityNewFeature();
        }

        /// <summary>
        /// add feature controller
        /// </summary>
        /// <param name="feature"></param>
        private void AddFeature(Feature feature)
        {
            FeatureController _featureController = null;
            switch (feature.featureType)
            {
                case Enum.FeatureType.CloneCharacter:
                    _featureController = new CloneFeatureController(this);
                    break;
                case Enum.FeatureType.QuickUp:
                    _featureController = new QuickUpFeatureController(this);
                    break;
                case Enum.FeatureType.DoubleShot:
                    _featureController = new DoubleShotFeatureController(this);
                    break;
                case Enum.FeatureType.SpeedUp:
                    _featureController = new SpeedUpFeatureController(this);
                    break;
                case Enum.FeatureType.TripleShot:
                    _featureController = new TripleFeatureController(this);
                    break;
            }
        }

        /// <summary>
        /// check additionality new feature according to skill controller count - max capacity = 3 
        /// </summary>
        /// <returns></returns>
        private void CheckAdditionalityNewFeature()
        {
            if(_features.Count >= 3)
            {
                EventManager.Instance.TriggerEvent(Enum.StateAction.FeatureButtonSetState.ToString(), false);
            }
        }
    }
}
