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

        /// <summary>
        /// fire 3 bullet with different angles (-45-0-45)
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="position"></param>
        public override void Fire(float angle, Vector3 position)
        {
            base.Fire(angle - 45f,position);
            base.Fire(angle,position);
            base.Fire(angle + 45f, position);
        }
    }
}
