using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class TripleFeatureController : FeatureController
    {
        public TripleFeatureController(SkillController skillController) : base(skillController)
        {
        }

        public override void SetFeature(SkillController skillController)
        {
            Debug.LogError("Set Feature triple");
            skillController.Attack = new TripleAttackController(skillController.Attack);
        }
    }
}
