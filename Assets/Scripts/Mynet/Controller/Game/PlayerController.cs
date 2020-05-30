using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Manager;
using DG.Tweening;

namespace Mynet.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public Vector3 onMenu;
        public Vector3 onGame;
        public SkillController featureController;

        void Awake()
        {
            InitConfiguration();
        }

        void InitConfiguration()
        {
            InitEvents();
        }

        /// <summary>
        /// set event listeners
        /// </summary>
        void InitEvents()
        {
            EventManager.Instance.StartListening(Enum.StateAction.OnGame.ToString(), OnGame);
            EventManager.Instance.StartListening(Enum.StateAction.OnMenu.ToString(), OnMenu);
        }

        /// <summary>
        /// on menu state configuration
        /// </summary>
        /// <param name="arg"></param>
        void OnMenu(System.Object arg = null)
        {
            transform.DOMove(onMenu, 1);
        }

        /// <summary>
        /// on game state configuration
        /// </summary>
        /// <param name="arg"></param>
        void OnGame(System.Object arg = null)
        {
            transform.DOMove(onGame, 1);

        }
    }
}
