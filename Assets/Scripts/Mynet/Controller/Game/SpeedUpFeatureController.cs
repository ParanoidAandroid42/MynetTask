using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class SpeedUpFeatureController : FeatureController
    {
        public SpeedUpFeatureController(SkillController skillController) : base(skillController)
        {
        }

        public override void SetFeature(SkillController skillController)
        {
            Debug.Log("Set Feature speedUp");
            skillController.Attack.FireSpeed += skillController.Attack.FireSpeed * 50 / 100;
        }
    }
}
