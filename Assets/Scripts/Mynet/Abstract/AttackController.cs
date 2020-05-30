using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mynet.Interface;

namespace Mynet.Abstract
{
    public abstract class AttackController : IAttackInterface
    {
        protected IAttackInterface _attack;

        public float FireRate { get => _attack.FireRate; set => _attack.FireRate = value; }
        public float FireSpeed { get => _attack.FireSpeed; set => _attack.FireSpeed = value; }

        public AttackController(IAttackInterface attackController)
        {
            _attack = attackController;
        }

        public virtual void Fire(float angle, Vector3 position)
        {
        }

        public virtual bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}
