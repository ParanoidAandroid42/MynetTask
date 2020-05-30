using DG.Tweening;
using Mynet.Data;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class GameUIController : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public Button restartButton;
        public CharacterSkillData characterSkillsData;

        private RectTransform _gameUITransform;
        private List<Button> _skillButtons;

        void Awake()
        {
            InitConfiguration();
        }

        void InitConfiguration()
        {
            _skillButtons = new List<Button>();
            _gameUITransform = GetComponent<RectTransform>();
            InitEvents();
            CreateSkillButtons();
        }

        /// <summary>
        /// set event listeners
        /// </summary>
        void InitEvents()
        {
            restartButton.onClick.AddListener(OnRestartButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
        }

        /// <summary>
        /// on click playbutton configuration
        /// </summary>
        void OnRestartButton()
        {
            restartButton.GetComponent<RectTransform>().DOAnchorPosX(145f, 0.5f).OnComplete(() =>
            {
                _gameUITransform.DOAnchorPosY(-800f, 3f);
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
                restartButton.GetComponent<RectTransform>().DOAnchorPosX(-10f, 0.5f);
            });
            SetButtonInteractable(true);
        }

        /// <summary>
        /// create all skill buttons according to character skills data
        /// </summary>
        void CreateSkillButtons()
        {
            for (int i = 0; i < characterSkillsData.skills.Count; i++)
            {
                CreateSkillButton(i, characterSkillsData.skills[i]);
            }
        }

        /// <summary>
        /// Set button interactable according to enable value
        /// </summary>
        /// <param name="enable">enable situation</param>
        void SetButtonInteractable(bool enable)
        {
            foreach (Button skillButton in _skillButtons)
            {
                skillButton.interactable = enable;
            }
        }

        void CreateSkillButton(int index, CharacterSkill skill)
        {
            int skillButtonCount = characterSkillsData.skills.Count;
            Vector2 position = new Vector2(index % skillButtonCount * 90f, index / skillButtonCount * 90f);
            SkillButton skillButton = new SkillButton(skill,buttonPrefab, _gameUITransform, new Vector2(index % 5 * 90f, index / 5 * 90f));
            _skillButtons.Add(skillButton.button);
        }
    }
}
