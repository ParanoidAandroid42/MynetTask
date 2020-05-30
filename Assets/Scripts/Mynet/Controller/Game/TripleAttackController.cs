using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class TripleAttackController : AttackController
    {
        public TripleAttackController(IAttackInterface attack) : base(attack)
        {
            
        }

        public override void Fire(float angle, Vector3 position)
        {
            Debug.LogError("Triple Shot Attack");
        }

        public override bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}
