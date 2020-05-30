using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class CloneFeatureController : FeatureController
    {
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
        }
    }
}
