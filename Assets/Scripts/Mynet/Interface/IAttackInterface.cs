using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mynet.Interface
{
    public interface IAttackInterface
    {
        bool IsAttacktimeUpdated(float currentTime);
        void Fire(float angle,Vector3 position);
    }
}
