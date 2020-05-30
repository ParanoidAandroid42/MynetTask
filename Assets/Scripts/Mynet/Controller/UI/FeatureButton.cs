using UnityEngine;
using UnityEngine.UI;
using Mynet.Data;
using Mynet.Manager;

public class FeatureButton : MonoBehaviour
{
    public Button button;
    private Feature _skill;

    public void InitConfiguration(Feature skill, GameObject prefab, Transform parent, Vector2 position)
    {
        GetComponent<RectTransform>().anchoredPosition = position;
        button = GetComponent<Button>();
        button.GetComponent<Image>().sprite = skill.image;
        button.onClick.AddListener(OnSkillButton);
        _skill = skill;
        InitEvents();
    }

    private void InitEvents()
    {
        EventManager.Instance.StartListening(Enum.StateAction.FeatureButtonSetState.ToString(), FeatureButtonSetState);
    }

    /// <summary>
    ///feature buttons state change
    /// </summary>
    /// <param name="arg"></param>
    private void FeatureButtonSetState(System.Object arg = null)
    {
        bool enable = (bool)arg;
        SetInteractive(enable);
    }

    /// <summary>
    /// set interactive according to enable param
    /// </summary>
    /// <param name="enable"></param>
    private void SetInteractive(bool enable)
    {
        button.interactable = enable;
    }

    /// <summary>
    /// When Press skill button 
    /// </summary>
    public void OnSkillButton()
    {
        EventManager.Instance.TriggerEvent(Enum.GameAction.OnFeatureButton.ToString(), _skill);
        SetInteractive(false);
    }
}
