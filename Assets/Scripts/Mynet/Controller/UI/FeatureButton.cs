using UnityEngine;
using UnityEngine.UI;
using Mynet.Data;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class FeatureButton : MonoBehaviour
    {
        public Button button;
        private Feature _skill;

        public void InitConfiguration(Feature skill, GameObject prefab, Transform parent, Vector2 position)
        {
            GetComponent<RectTransform>().anchoredPosition = position;
            button = GetComponent<Button>();
            button.GetComponent<Image>().sprite = skill.image;
            button.onClick.AddListener(OnFeatureButton);
            _skill = skill;
            InitEvents();
        }

        private void InitEvents()
        {
            EventManager.Instance.StartListening(Enum.StateAction.FeatureButtonSetState.ToString(), FeatureButtonSetState);
        }

        /// <summary>
        ///feature buttons state change
        /// </summary>
        /// <param name="arg"></param>
        private void FeatureButtonSetState(System.Object arg = null)
        {
            bool enable = (bool)arg;
            SetInteractive(enable);
        }

        /// <summary>
        /// set interactive according to enable param
        /// </summary>
        /// <param name="enable"></param>
        private void SetInteractive(bool enable)
        {
            button.interactable = enable;
        }

        /// <summary>
        /// run the methow when press feature button 
        /// </summary>
        public void OnFeatureButton()
        {
            EventManager.Instance.TriggerEvent(Enum.GameAction.OnFeatureButton.ToString(), _skill);
            SetInteractive(false);
        }
    }
}
