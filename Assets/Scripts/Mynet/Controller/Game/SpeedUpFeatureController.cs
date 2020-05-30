using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

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
            attackController.FireSpeed += attackController.FireSpeed * 50 / 100;
        }
    }
}
