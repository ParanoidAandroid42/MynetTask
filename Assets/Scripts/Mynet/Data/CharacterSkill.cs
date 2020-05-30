using UnityEngine;

namespace Mynet.Data
{
    [CreateAssetMenu(fileName = "NewCharacterSkill", menuName = "Character Skill", order = 1)]
    public class CharacterSkill : ScriptableObject
    {
        public Enum.SkillType skillType;
        public Sprite image;
        [TextArea] public string skillInfo;
    }
}
