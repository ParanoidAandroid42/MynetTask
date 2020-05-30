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
        public float RateOffset { get => _attack.RateOffset; set => _attack.RateOffset = value; }

        /// <summary>
        /// attack controller init
        /// </summary>
        /// <param name="attack"></param>
        public AttackController(IAttackInterface attack)
        {
            _attack = attack;
        }

        /// <summary>
        /// bullet shoot
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="position"></param>
        public virtual void Fire(float angle, Vector3 position)
        {
            _attack.Fire(angle, position);
        }

        /// <summary>
        /// check time update - acording to firerate
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public virtual bool IsAttacktimeUpdated(float currentTime)
        {
            return _attack.IsAttacktimeUpdated(currentTime);
        }
    }
}
