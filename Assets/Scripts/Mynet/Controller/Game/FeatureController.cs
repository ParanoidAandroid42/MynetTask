using UnityEngine;
using Mynet.Interface;

namespace Mynet.Controller
{
    //this class is abstract ; beause maybe it will be expandable.
    public abstract class FeatureController: IFeatureInterface
    {
        public FeatureController(IAttackInterface attackController)
        {
            SetFeature(attackController);
        }

        public virtual void SetFeature(IAttackInterface attackController)
        {
             // can be added some base codes. just now, anycode in here.
        }
    }
}
