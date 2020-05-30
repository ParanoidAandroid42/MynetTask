using System.Collections.Generic;
using UnityEngine;

namespace Mynet.Data
{
    [CreateAssetMenu(fileName = "NewCharacterSkillData", menuName = "Character Skill Data", order = 2)]
    public class CharacterSkillData : ScriptableObject
    {
        public List<CharacterSkill> skills;
    }
}
