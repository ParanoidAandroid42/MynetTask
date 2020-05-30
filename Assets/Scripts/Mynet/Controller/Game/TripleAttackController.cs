using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class TripleAttackController : AttackController
    {
        public TripleAttackController(IAttackInterface attackController) : base(attackController) { }

        public override void Fire(float angle, Vector3 position)
        {

        }

        public override bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}
