using UnityEngine;
using System.Collections;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class TripleFeatureController : FeatureController
    {
        public TripleFeatureController(IAttackInterface attackController) : base(attackController) {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature triple");
        }
    }
}
