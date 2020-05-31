﻿using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class DoubleShotAttackController : AttackController
    {
        const float _OFFSET_RATE_ = 0.3f;
        private float _bulletRateOffsetTime;

        /// <summary>
        /// init properties
        /// </summary>
        /// <param name="attack"></param>
        public DoubleShotAttackController(IAttackInterface attack) : base(attack)
        {
            _bulletRateOffsetTime = 0f;
        }

        /// <summary>
        /// attack bullet
        /// </summary>
        /// <param name="angle">direction</param>
        /// <param name="position">posiiton</param>
        public override void Fire(float angle, Vector3 position)
        {
            Debug.Log("Double Shot Attack");
            base.Fire(angle,position);
        }

        /// <summary>
        /// checck attack time according to currentTime
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public override bool IsAttacktimeUpdated(float currentTime)
        {
            if (_bulletRateOffsetTime == 0f)
            {
                if (base.IsAttacktimeUpdated(currentTime))
                {
                    _bulletRateOffsetTime = _OFFSET_RATE_;
                    return true;
                }
                return false;
            }
            else
            {
                _bulletRateOffsetTime -= currentTime;
                if (_bulletRateOffsetTime <= 0f)
                {
                    _bulletRateOffsetTime = 0f;
                    return true;
                }
                return false;
            }
        }
    }
}
