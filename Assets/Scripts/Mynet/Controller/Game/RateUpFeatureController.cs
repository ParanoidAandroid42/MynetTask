using UnityEngine;
using System.Collections;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class RateUpFeatureController : FeatureController
    {
        public RateUpFeatureController(IAttackInterface attackController) : base(attackController)
        {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature rate up");
        }
    }
}
