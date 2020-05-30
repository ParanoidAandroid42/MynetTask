using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Manager;

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
