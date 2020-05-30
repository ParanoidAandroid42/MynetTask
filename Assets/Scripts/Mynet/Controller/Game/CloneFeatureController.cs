using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class CloneFeatureController : FeatureController
    {
        public CloneFeatureController(IAttackInterface attackController) : base(attackController) { }

        public override void SetFeature(IAttackInterface attackController)
        {
            Debug.LogError("Set Feature Clone");
            attackController = new CloneShotAttackController(attackController);
        }
    }
}
