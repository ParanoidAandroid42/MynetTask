using UnityEngine;
using Mynet.Interface;
using Mynet.Controller;

namespace Mynet.Abstract
{
    //this class is abstract ; beause maybe it will be expandable.
    public abstract class FeatureController: IFeatureInterface
    {
        /// <summary>
        /// init configuration
        /// </summary>
        /// <param name="skillController"></param>
        public FeatureController(SkillController skillController)
        {
            SetFeature(skillController);
        }

        /// <summary>
        /// Set feature init configuration
        /// </summary>
        /// <param name="skillController"></param>
        public abstract void SetFeature(SkillController skillController);
    }
}
