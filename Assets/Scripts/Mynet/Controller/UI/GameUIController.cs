using DG.Tweening;
using Mynet.Data;
using UnityEngine;
using UnityEngine.UI;
using Mynet.Manager;
using System.Collections.Generic;

namespace Mynet.Controller
{
    public class GameUIController : MonoBehaviour
    {
        [Header("Feature button prefab")]
        public GameObject buttonPrefab;
        [Header("quit button")]
        public Button quitButton;
        [Header("character's skills data")]
        public CharacterFeatureData characterSkillsData;

        private RectTransform _gameUITransform;

        void Awake()
        {
            InitConfiguration();
        }

        /// <summary>
        /// init properties
        /// </summary>
        void InitConfiguration()
        {
            _gameUITransform = GetComponent<RectTransform>();
            InitEvents();
            CreateSkillButtons();
        }

        /// <summary>
        /// set event listeners
        /// </summary>
        void InitEvents()
        {
            quitButton.onClick.AddListener(OnQuitButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
        }

        /// <summary>
        /// on click quitbutton configuration
        /// </summary>
        void OnQuitButton()
        {
            quitButton.GetComponent<RectTransform>().DOAnchorPosX(150f, 0.5f).OnComplete(() =>
            {
                _gameUITransform.DOAnchorPosY(-800f, 3f);
                EventManager.Instance.TriggerEvent(Enum.StateAction.OnMenu.ToString());
            });
        }

        /// <summary>
        /// on game state configuration
        /// </summary>
        /// <param name="arg"></param>
        void OnGame(System.Object arg = null)
        {
            _gameUITransform.DOAnchorPosY(0, 1).OnComplete(() =>
            {
                quitButton.GetComponent<RectTransform>().DOAnchorPosX(-10f, 0.55f);
                EventManager.Instance.TriggerEvent(Enum.StateAction.FeatureButtonSetState.ToString(), true);
            });
        }

        /// <summary>
        /// create all skill buttons according to character's skills data
        /// </summary>
        void CreateSkillButtons()
        {
            for (int i = 0; i < characterSkillsData.feature.Count; i++)
            {
                CreateFeatureButton(i, characterSkillsData.feature[i]);
            }
        }

        /// <summary>
        /// create feature button 
        /// </summary>
        /// <param name="index">index</param>
        /// <param name="feature">feature data</param>
        void CreateFeatureButton(int index, Feature feature)
        {
            int featureButtonCount = characterSkillsData.feature.Count;
            float x = index % featureButtonCount * 90f;
            float y = index / featureButtonCount * 90f;
            Vector2 position = new Vector2(x,y);

            GameObject fBO = Instantiate(buttonPrefab, _gameUITransform);
            fBO.AddComponent<FeatureButton>();
            FeatureButton fB = fBO.GetComponent<FeatureButton>();
            fBO.GetComponent<FeatureButton>().InitConfiguration(feature, buttonPrefab, _gameUITransform, position);
        }
    }
}
