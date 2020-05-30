
using UnityEngine;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class GameController : MonoBehaviour
    {

        void Start()
        {
            EventManager.Instance.TriggerEvent(Enum.StateAction.OnMenu.ToString());
            InitEvents();
        }

        /// <summary>
        /// init events
        /// </summary>
        private void InitEvents()
        {

        }

        public void ClearObjects()
        {
            PlayerController[] characters = FindObjectsOfType<PlayerController>();
            Destroy(characters[0].gameObject);
        }
    }
}
