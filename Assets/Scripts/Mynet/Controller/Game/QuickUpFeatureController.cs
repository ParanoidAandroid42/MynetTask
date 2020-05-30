using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class QuickUpFeatureController : FeatureController
    {
        public QuickUpFeatureController(SkillController skillController) : base(skillController)
        {
        }

        public override void SetFeature(SkillController skillController)
        {
            Debug.Log("Set Feature quick up");
            skillController.Attack.FireRate /= 2;
        }
    }
}
