using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class TripleAttackController : AttackController
    {
        public TripleAttackController(IAttackInterface attack) : base(attack)
        {
            _attack = attack;
        }

        public override void Fire(float angle, Vector3 position)
        {
            Debug.Log("Triple Shot Attack");
            base.Fire(angle - 45f,position);
            base.Fire(angle,position);
            base.Fire(angle + 45f, position);
        }
    }
}
