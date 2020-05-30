using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class DoubleShotFeatureController : FeatureController
    {
        public DoubleShotFeatureController(IAttackInterface attackController) : base(attackController)
        {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature rate up");
            attackController = new DoubleShotAttackController(attackController);
        }
    }
}
