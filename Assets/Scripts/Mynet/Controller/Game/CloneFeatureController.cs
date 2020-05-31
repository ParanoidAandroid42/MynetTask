using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;
using Mynet.Manager;

namespace Mynet.Controller
{
    public class CloneFeatureController : FeatureController
    {
        private Vector2 _minSpawnPos = new Vector2(-10f, 20f);
        private Vector2 _maxSpawnPos = new Vector2(10f, 30f);

        public CloneFeatureController(SkillController skillController) : base(skillController) { }

        /// <summary>
        /// set clone player
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            GameObject clone = MonoBehaviour.Instantiate(skillController.gameObject);

            SkillController skill = skillController.gameObject.GetComponent<SkillController>();
            float randX = Random.Range(_minSpawnPos.x, _maxSpawnPos.x);
            float randY = Random.Range(_minSpawnPos.y, _maxSpawnPos.y);
            Vector2 randomPos = new Vector2(randX, randY);
            clone.transform.position = randomPos;
            clone.transform.rotation = skillController.transform.rotation;
            clone.GetComponent<SkillController>().Clone(skill.Features, skill.Attack.CurrentTime);
            clone.tag = Enum.Tag.Clone.ToString();
        }
    }
}
