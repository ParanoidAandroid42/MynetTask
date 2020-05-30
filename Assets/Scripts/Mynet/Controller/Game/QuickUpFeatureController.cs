using UnityEngine;
using System.Collections;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class QuickUpFeatureController : FeatureController
    {
        public QuickUpFeatureController(IAttackInterface attackController) : base(attackController)
        {
        }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature quick up");
        }
    }
}
