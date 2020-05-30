using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class DoubleShotFeatureController : FeatureController
    {
        public DoubleShotFeatureController(SkillController skillController) : base(skillController)
        {
        }

        public override void SetFeature(SkillController skillController)
        {
            Debug.LogError("Set Feature rate up");
            skillController.Attack = new DoubleShotAttackController(skillController.Attack);
        }
    }
}
