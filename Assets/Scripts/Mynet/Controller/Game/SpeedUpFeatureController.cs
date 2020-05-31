using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class SpeedUpFeatureController : FeatureController
    {
        public SpeedUpFeatureController(SkillController skillController) : base(skillController) { }

        /// <summary>
        /// Set feature init configuration
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            skillController.Attack.FireSpeed += skillController.Attack.FireSpeed * 50 / 100;
        }
    }
}
