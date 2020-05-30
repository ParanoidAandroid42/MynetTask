using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mynet.Manager
{ 
    public class PoolerManager : MonoBehaviour
    {
        private Dictionary<string, Queue<GameObject>> _poolerDictionary;
        private List<Pool> _pools;

        #region singleton
        public static PoolerManager Instance;

        #endregion

        [System.Serializable]
        public class Pool
        {
            public Enum.Tag tag;
            public GameObject prefab;
            public int size;
        }

        void Awake()
        {
            Instance = this;
            Init();
        }

        /// <summary>
        /// init properties
        /// </summary>
        void Init()
        {
            _poolerDictionary = new Dictionary<string, Queue<GameObject>>();
        }

        /// <summary>
        /// add pools according to pool data
        /// </summary>
        /// <param name="poolData"></param>
        public void AddPools(Pool poolData)
        {
            if (!_poolerDictionary.ContainsKey(poolData.tag.ToString()))
            {
                Queue<GameObject> pO = new Queue<GameObject>();
                for (int i = 0; i < poolData.size; i++)
                {
                    GameObject o = Instantiate(poolData.prefab, transform);
                    o.SetActive(false);
                    pO.Enqueue(o);
                }

                _poolerDictionary.Add(poolData.tag.ToString(), pO);
            }
        }

        /// <summary>
        /// get pool according to tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public GameObject GetPool(Enum.Tag tag)
        {
            GameObject pool = _poolerDictionary[tag.ToString()].Dequeue();
            pool.SetActive(true);
            return pool;
        }

        /// <summary>
        /// add enque according to tag
        /// </summary>
        /// <param name="gO"></param>
        /// <param name="tag"></param>
        public void AddEnqueue(GameObject gO,Enum.Tag tag)
        {
            _poolerDictionary[tag.ToString()].Enqueue(gO);
            gO.SetActive(false);
        }
    }
}
