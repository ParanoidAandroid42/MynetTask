using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class CloneFeatureController : FeatureController
    {
        readonly Vector2 _MINIMUM = new Vector2(-10f, 20f);
        readonly Vector2 _MAXIMUM = new Vector2(10f, 30f);

        public CloneFeatureController(SkillController skillController) : base(skillController)
        {
        }

        /// <summary>
        /// set clone player
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            Debug.Log("Set Feature Clone");
            GameObject clone = MonoBehaviour.Instantiate(skillController.gameObject);

            SkillController skill = skillController.gameObject.GetComponent<SkillController>();
            Vector2 randomPos = new Vector2(Random.Range(_MINIMUM.x, _MAXIMUM.x), Random.Range(_MINIMUM.y, _MAXIMUM.y));
            clone.transform.position = randomPos;
            clone.GetComponent<SkillController>().Clone(skill.features);
            clone.tag = Enum.Tag.Clone.ToString();
        }
    }
}
