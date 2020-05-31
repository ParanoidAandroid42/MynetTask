using UnityEngine;

namespace Mynet.Interface
{
    public interface IAttackInterface
    {
        float FireRate { get; set; }
        float FireSpeed { get; set; }
        float RateOffset { get; set; }
        bool IsAttacktimeUpdated(float currentTime);
        void Fire(float angle,Vector3 position);
    }
}
