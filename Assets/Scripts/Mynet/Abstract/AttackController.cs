using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Interface;

namespace Mynet.Abstract
{
    public abstract class AttackController : IAttackInterface
    {
        public void Fire(float angle, Vector3 position)
        {
        }

        public bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}
