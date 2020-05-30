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

        private readonly GameObject _bulletPrefab;
        private float _currentTime;

        /// <summary>
        /// base range attack controller init
        /// </summary>
        /// <param name="bulletPrefab">bullet prefab </param>
        /// <param name="fireSpeed">fire speed</param>
        /// <param name="fireRate">fire rate</param>
        /// <param name="rateOffset">rate offset</param>
        public BaseRangeAttackController(GameObject bulletPrefab, float fireSpeed, float fireRate,float rateOffset)
        {
            _bulletPrefab = bulletPrefab;
            _currentTime = 0;

            FireSpeed = fireSpeed;
            FireRate = fireRate;
            RateOffset = rateOffset;
        }

        /// <summary>
        /// shot bullet 
        /// </summary>
        /// <param name="angle">direction</param>
        /// <param name="position">spawn position</param>
        public void Fire(float angle, Vector3 position)
        {
            PoolerManager.Pool poolData = new PoolerManager.Pool();
            poolData.size = 15;
            poolData.prefab = _bulletPrefab;
            poolData.tag = Enum.Tag.FireBall;
            PoolerManager.Instance.AddPools(poolData);
            GameObject bullet = PoolerManager.Instance.GetPool(Enum.Tag.FireBall);
            bullet.transform.position = position;

            Vector3 target = bullet.transform.position;

            target.x += 15 * Mathf.Cos(angle * Mathf.Deg2Rad);
            target.y += 15 * Mathf.Sin(angle * Mathf.Deg2Rad);

            bullet.transform.DOMove(target, 15 / FireSpeed).OnComplete(() =>
            {
                PoolerManager.Instance.AddEnqueue(bullet,Enum.Tag.FireBall);
            });
        }

        /// <summary>
        /// check enable time update
        /// </summary>
        /// <param name="currentTime"></param>
        /// <returns></returns>
        public bool IsAttacktimeUpdated(float currentTime)
        {
            if ((_currentTime += currentTime) > FireRate)
            {
                _currentTime = 0;
                return true;
            }
            return false;
        }
    }
}
