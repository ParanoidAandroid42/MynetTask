using DG.Tweening;
using Mynet.Data;
using UnityEngine;
using UnityEngine.UI;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class GameUIController : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public Button quitButton;
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
            quitButton.GetComponent<RectTransform>().DOAnchorPosX(145f, 0.5f).OnComplete(() =>
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
            _gameUITransform.DOAnchorPosY(0f, 1f).OnComplete(() =>
            {
                quitButton.GetComponent<RectTransform>().DOAnchorPosX(-10f, 0.5f);
                EventManager.Instance.TriggerEvent(Enum.StateAction.FeatureButtonSetState.ToString(), true);
            });
        }

        /// <summary>
        /// create all skill buttons according to character skills data
        /// </summary>
        void CreateSkillButtons()
        {
            for (int i = 0; i < characterSkillsData.feature.Count; i++)
            {
                CreateSkillButton(i, characterSkillsData.feature[i]);
            }
        }

        /// <summary>
        /// create skill button 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="skill"></param>
        void CreateSkillButton(int index, Feature skill)
        {
            int skillButtonCount = characterSkillsData.feature.Count;
            Vector2 position = new Vector2(index % skillButtonCount * 90f, index / skillButtonCount * 90f);

            GameObject skillButton = MonoBehaviour.Instantiate(buttonPrefab, _gameUITransform);
            skillButton.AddComponent<FeatureButton>();
            skillButton.GetComponent<FeatureButton>().InitConfiguration(skill, buttonPrefab, _gameUITransform, position);
        }
    }
}
