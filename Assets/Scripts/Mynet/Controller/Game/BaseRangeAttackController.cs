using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;
using DG.Tweening;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class BaseRangeAttackController : IAttackInterface
    {
        public float FireRate { get ; set ; }
        public float FireSpeed { get; set; }
        public float RateOffset { get; set; }
        public float CurrentTime { get; set; }

        private readonly GameObject _bulletPrefab;

        /// <summary>
        /// base range attack controller init
        /// </summary>
        /// <param name="bulletPrefab">bullet prefab </param>
        /// <param name="fireSpeed">fire speed</param>
        /// <param name="fireRate">fire rate</param>
        /// <param name="rateOffset">rate offset</param>
        /// <param name="currentTime">start time</param>
        public BaseRangeAttackController(GameObject bulletPrefab, float fireSpeed, float fireRate,float rateOffset,float currentTime)
        {
            _bulletPrefab = bulletPrefab;

            FireSpeed = fireSpeed;
            FireRate = fireRate;
            RateOffset = rateOffset;
            CurrentTime = currentTime;
        }

        /// <summary>
        /// shot bullet 
        /// </summary>
        /// <param name="angle">direction</param>
        /// <param name="position">spawn position</param>
        public void Fire(float angle, Vector3 position)
        {
            PoolerManager.Instance.AddPools(_bulletPrefab,Enum.Tag.FireBall,35);
            GameObject bullet = PoolerManager.Instance.GetPool(Enum.Tag.FireBall);
            bullet.transform.position = position;
            bullet.GetComponent<BulletController>().UpdateConfiguration(FireSpeed, angle);
        }

        /// <summary>
        /// check enable time update
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public bool IsAttacktimeUpdated(float currentTime)
        {
            if ((CurrentTime += currentTime) > FireRate)
            {
                CurrentTime = 0;
                return true;
            }
            return false;
        }
    }
}
