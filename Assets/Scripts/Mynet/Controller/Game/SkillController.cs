using System.Collections;
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
        public float fireRate;
        public float fireSpeed;
        public float rateOffset = 2;
        public GameObject bulletPrefab;

        private IAttackInterface _attack;
        private Dictionary<Enum.FeatureType, FeatureController> _featureControllers;

        public IAttackInterface Attack { get => _attack; set => _attack = value; }

        private bool _gameStart;

        public void Awake()
        {
            InitConfigurations();
        }

        public void InitConfigurations()
        {
            InitEvents();
        }

        public void StartGame()
        {
            _featureControllers = new Dictionary<Enum.FeatureType, FeatureController>();
            _attack = new BaseRangeAttackController(bulletPrefab, fireSpeed, fireRate,rateOffset);
            _gameStart = true;
        }

        public void Update()
        {
            if (_gameStart && _attack.IsAttacktimeUpdated(Time.deltaTime))
            {
                _attack.Fire(transform.eulerAngles.x,transform.position);
            }
        }

        public void InitEvents()
        {
            EventManager.Instance.StartListening(Enum.GameAction.OnFeatureButton.ToString(), OnFeatureButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
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
        /// add new feature according to pressed feature button
        /// </summary>
        /// <param name="feature"></param>
        public void AddNewFeature(Feature feature)
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
            _featureControllers.Add(feature.featureType, _featureController);
            CheckAdditionalityNewFeature();
        }
        

        /// <summary>
        /// check additionality new feature according to skill controller count - max capacity = 3 
        /// </summary>
        /// <returns></returns>
        private void CheckAdditionalityNewFeature()
        {
            if(_featureControllers.Count >= 3)
            {
                EventManager.Instance.TriggerEvent(Enum.StateAction.FeatureButtonSetState.ToString(), false);
            }
        }
    }
}
