
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

        private void InitEvents()
        {

        }
    }
}
