using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class DoubleShotAttackController : AttackController
    {
        public DoubleShotAttackController(IAttackInterface attack) : base(attack)
        {
        }

        public override void Fire(float angle, Vector3 position)
        {
            Debug.LogError("Double Shot Attack");
        }

        public override bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}
