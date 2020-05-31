using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Manager;
using DG.Tweening;

namespace Mynet.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [Header("position in the menu")]
        public Vector3 onMenuPosition;
        [Header("position in the game")]
        public Vector3 onGamePosition;

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
            transform.DOMove(onMenuPosition, 1).onComplete = () =>
            {
                ClearClones();
            };
        }

        public void ClearClones()
        {
            if(tag == Enum.Tag.Clone.ToString())
            {
                Destroy(gameObject);//TODO -maybe can be spawn by pooling manager
            }
        }

        /// <summary>
        /// on game state configuration
        /// </summary>
        /// <param name="arg"></param>
        void OnGame(System.Object arg = null)
        {
            transform.DOMove(onGamePosition, 1);
        }
    }
}
