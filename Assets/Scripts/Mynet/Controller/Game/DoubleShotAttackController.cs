using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class DoubleShotAttackController : AttackController
    {
        const float _OFFSET_RATE_ = 0.2f;
        private float _bulletRateOffsetTime;

        public DoubleShotAttackController(IAttackInterface attack) : base(attack)
        {
            _bulletRateOffsetTime = 0f;
        }

        public override void Fire(float angle, Vector3 position)
        {
            Debug.LogError("Double Shot Attack");
            base.Fire(angle,position);
        }

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
