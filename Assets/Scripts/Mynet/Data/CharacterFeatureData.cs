using System.Collections.Generic;
using UnityEngine;

namespace Mynet.Data
{
    /// <summary>
    /// You can create your character feature data -> right mouse - create - Feature - New Character Skill Data
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacterFeatureData", menuName = "Feature/New Character Feature Data", order = 2)]
    public class CharacterFeatureData : ScriptableObject
    {
        [Header("Please add the features you want")]
        public List<Feature> feature;
    }
}
