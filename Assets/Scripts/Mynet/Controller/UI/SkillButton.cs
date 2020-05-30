using UnityEngine;
using UnityEngine.UI;
using Mynet.Data;

public class SkillButton : MonoBehaviour
{
    public Button button;
    
    public SkillButton(CharacterSkill skill,GameObject prefab, Transform parent,Vector2 position)
    {
        GameObject skillButton = Instantiate(prefab, parent);
        skillButton.GetComponent<RectTransform>().anchoredPosition = position;
        button = skillButton.GetComponent<Button>();
        button.GetComponent<Image>().sprite = skill.image;
    }
}
