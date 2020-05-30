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
            transform.DOMove(onMenu, 1).onComplete = () =>
            {
                ClearObjects();
            };
        }

        public void ClearObjects()
        {
            if(tag == Enum.Tag.Clone.ToString())
            {
                Destroy(gameObject);
            }
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
