using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class CloneFeatureController : FeatureController
    {
        const float _Z_ = -.5f;
        readonly Vector2 _MIN_ = new Vector2(-10f, 20f);
        readonly Vector2 _MAX_ = new Vector2(10f, 30f);

        public CloneFeatureController(SkillController skillController) : base(skillController)
        {
        }

        /// <summary>
        /// set clone player
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            Debug.LogError("Set Feature Clone");
            PoolerManager.Pool poolData = new PoolerManager.Pool();
            poolData.size = 1;
            poolData.prefab = skillController.gameObject;
            poolData.tag = Enum.Tag.Player;
            PoolerManager.Instance.AddPools(poolData);
            GameObject clone = PoolerManager.Instance.GetPool(Enum.Tag.Player);

            GameObject objectToBeCloned = skillController.gameObject;
            Vector3 rndpos = new Vector3(Random.Range(_MIN_.x, _MAX_.x), Random.Range(_MIN_.y, _MAX_.y), _Z_);
            clone.transform.position = rndpos;
            clone.GetComponent<SkillController>().Clone(objectToBeCloned.GetComponent<SkillController>().features);
        }
    }
}
