using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class MenuUIController : MonoBehaviour
    {
        private RectTransform _transform;
        public Button playButton;

        void Awake()
        {
            _transform = GetComponent<RectTransform>();
            InitEvents();
        }

        /// <summary>
        /// set event listeners
        /// </summary>
        void InitEvents()
        {
            playButton.onClick.AddListener(OnPlayButton);
            EventManager.Instance.StartListening(Enum.StateAction.OnMenu.ToString(), OnMenu);
        }

        /// <summary>
        /// on click playbutton configuration
        /// </summary>
        void OnPlayButton()
        {
            _transform.DOAnchorPosX(-450f, 1f).OnComplete(() =>
            {
                _transform.anchoredPosition = new Vector2(450f, 0f);
                EventManager.Instance.TriggerEvent(Enum.StateAction.OnGame.ToString());
            });
        }

        /// <summary>
        /// on menu state configuration
        /// </summary>
        /// <param name="arg"></param>
        void OnMenu(System.Object arg = null)
        {
            _transform.DOAnchorPosX(0f, 1f);
        }
    }
}
