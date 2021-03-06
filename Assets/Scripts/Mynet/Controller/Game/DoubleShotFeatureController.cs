﻿using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class DoubleShotFeatureController : FeatureController
    {
        public DoubleShotFeatureController(SkillController skillController) : base(skillController) { }

        /// <summary>
        /// add new feature to skillcontroller
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            skillController.Attack = new DoubleShotAttackController(skillController.Attack);
        }
    }
}
