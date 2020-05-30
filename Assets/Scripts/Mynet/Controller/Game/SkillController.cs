using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Interface;
using Mynet.Manager;
using Mynet.Data;

namespace Mynet.Controller
{
    public class SkillController : MonoBehaviour
    {
        public float fireRate;
        public float fireSpeed;
        public GameObject bulletPrefab;

        private IAttackInterface _attack;
        private Dictionary<Enum.FeatureType, FeatureController> _featureControllers;

        public IAttackInterface Attack { get => _attack; set => _attack = value; }

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
                    _featureController = new CloneFeatureController(_attack);
                    break;
                case Enum.FeatureType.QuickUp:
                    _featureController = new QuickUpFeatureController(_attack);
                    break;
                case Enum.FeatureType.RateUp:
                    _featureController = new RateUpFeatureController(_attack);
                    break;
                case Enum.FeatureType.SpeedUp:
                    _featureController = new SpeedUpFeatureController(_attack);
                    break;
                case Enum.FeatureType.TripleShot:
                    _featureController = new TripleFeatureController(_attack);
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
