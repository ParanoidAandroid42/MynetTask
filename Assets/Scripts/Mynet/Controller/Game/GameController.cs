
using UnityEngine;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class GameController : MonoBehaviour
    {
        void Start()
        {
            InitEvents();
        }

        void InitConfiguration()
        {
            //just for now ,this place is empty but can be added some configuration -for expand
        }

        /// <summary>
        /// init events
        /// </summary>
        private void InitEvents()
        {
            EventManager.Instance.TriggerEvent(Enum.StateAction.OnMenu.ToString());
        }
    }
}
