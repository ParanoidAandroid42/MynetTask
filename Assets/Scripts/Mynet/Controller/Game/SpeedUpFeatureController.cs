using UnityEngine;
using System.Collections;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class SpeedUpFeatureController : FeatureController
    {
        public SpeedUpFeatureController(IAttackInterface attackController) : base(attackController)
        {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature speedUp");
        }
    }
}
