using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;
using DG.Tweening;

namespace Mynet.Controller
{
    public class BaseRangeAttackController : IAttackInterface
    {
        public float FireRate { get ; set ; }
        public float FireSpeed { get; set; }
        public float RateOffset { get; set; }

        private readonly GameObject _bulletPrefab;
        private float _currentTime;

        public BaseRangeAttackController(GameObject bulletPrefab, float fireSpeed, float fireRate,float rateOffset)
        {
            _bulletPrefab = bulletPrefab;
            _currentTime = Time.deltaTime;

            FireSpeed = fireSpeed;
            FireRate = FireRate;
            RateOffset = rateOffset;
        }

        public void Fire(float angle, Vector3 position)
        {
            Debug.LogError("Base attack");
        }

        public bool IsAttacktimeUpdated(float currentTime)
        {
            if ((currentTime - _currentTime) > FireRate)
            {
                _currentTime = Time.deltaTime;
                return true;
            }
            return false;
        }
    }
}
