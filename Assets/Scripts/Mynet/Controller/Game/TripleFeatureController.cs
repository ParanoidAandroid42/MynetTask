using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class TripleFeatureController : FeatureController
    {
        public TripleFeatureController(SkillController skillController) : base(skillController) { }

        /// <summary>
        /// Set feature init configuration
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            skillController.Attack = new TripleAttackController(skillController.Attack);
        }
    }
}
