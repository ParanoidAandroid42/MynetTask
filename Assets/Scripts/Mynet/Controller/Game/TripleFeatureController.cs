using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class TripleFeatureController : FeatureController
    {
        public TripleFeatureController(IAttackInterface attackController) : base(attackController) {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature triple");
            attackController = new TripleAttackController(attackController);
        }
    }
}
