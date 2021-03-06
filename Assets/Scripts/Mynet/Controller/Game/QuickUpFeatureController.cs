﻿using UnityEngine;
using System.Collections;
using Mynet.Interface;
using Mynet.Abstract;

namespace Mynet.Controller
{
    public class QuickUpFeatureController : FeatureController
    {
        public QuickUpFeatureController(SkillController skillController) : base(skillController) { }

        /// <summary>
        /// Set feature init configuration
        /// </summary>
        /// <param name="skillController"></param>
        public override void SetFeature(SkillController skillController)
        {
            skillController.Attack.FireRate /= 2;
        }
    }
}
