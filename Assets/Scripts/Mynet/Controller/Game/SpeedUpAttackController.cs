﻿using UnityEngine;
using Mynet.Abstract;
using Mynet.Interface;

namespace Mynet.Controller
{
    public class SpeedUpAttackController : AttackController
    {
        public SpeedUpAttackController(IAttackInterface attackController) : base(attackController) { }

        public override void Fire(float angle, Vector3 position)
        {

        }

        public override bool IsAttacktimeUpdated(float currentTime)
        {
            return false;
        }
    }
}