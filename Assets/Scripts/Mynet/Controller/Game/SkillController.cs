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
            EventManager.Instance.StartListening(Enum.GameAction.OnSkillButton.ToString(), OnSkillButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
        }

        public void OnSkillButton(System.Object arg = null)
        {
            Feature skill = (Feature)arg;
            AddNewSkill(skill);
        }

        public void OnGame(System.Object arg = null)
        {
            StartGame();
        }

        public void AddNewSkill(Feature skill)
        {
            FeatureController _featureController = null;
            switch (skill.featureType)
            {
                case Enum.FeatureType.CloneCharacter:
                    _featureController = new FeatureController();
                    break;
                case Enum.FeatureType.QuickUp:
                    _featureController = new FeatureController();
                    break;
                case Enum.FeatureType.RateUp:
                    _featureController = new FeatureController();
                    break;
                case Enum.FeatureType.SpeedUp:
                    _featureController = new FeatureController();
                    break;
                case Enum.FeatureType.TripleShot:
                    _featureController = new FeatureController();
                    break;
            }
            _featureControllers.Add(skill.featureType, _featureController);
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
