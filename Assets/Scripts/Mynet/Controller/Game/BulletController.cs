using UnityEngine;
using System.Collections;
using Mynet.Manager;


namespace Mynet.Controller
{
    public class BulletController : MonoBehaviour
    {
        private float _speed;
        private float _angle;
        private Rigidbody _rb;

        public void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void OnEnable()
        {
            Invoke("AddQuee", 2f);
        }

        /// <summary>
        /// update configuration according to spped and angle parameter
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="angle"></param>
        public void UpdateConfiguration(float speed, float angle)
        {
            Vector3 rotation = new Vector3(0, angle, 0);
            transform.rotation = Quaternion.EulerAngles(rotation);
            _speed = speed;
            _angle = angle;
        }

        /// <summary>
        /// add quee again
        /// </summary>
        public void AddQuee()
        {
            PoolerManager.Instance.AddEnqueue(gameObject, Enum.Tag.FireBall);
        }

        void FixedUpdate()
        {
            if (_speed != 0 && _rb != null)
            {
                _rb.position += (-transform.forward * _speed * Time.deltaTime);
            }
        }
    }
}
