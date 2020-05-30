using UnityEngine;

namespace Mynet.Data
{ 
    /// <summary>
    /// You can create your feature data -> right mouse - create - Feature - New Feature
     /// </summary>
    [CreateAssetMenu(fileName = "NewCharacterFeature", menuName = "Feature/New Feature", order = 1)]
    public class Feature : ScriptableObject
    {
        [Header("Please Select Feature type")]
        public Enum.FeatureType featureType;
        [Header("Please Select Feature's sprite")]
        public Sprite image;
        [TextArea] public string featureInfo;
    }
}
