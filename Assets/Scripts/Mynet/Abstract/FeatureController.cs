using UnityEngine;
using Mynet.Interface;
using Mynet.Controller;

namespace Mynet.Abstract
{
    //this class is abstract ; beause maybe it will be expandable.
    public abstract class FeatureController: IFeatureInterface
    {
        public FeatureController(SkillController skillController)
        {
            SetFeature(skillController);
        }

        public abstract void SetFeature(SkillController skillController);
    }
}
