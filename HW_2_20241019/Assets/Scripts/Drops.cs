using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drops : MonoBehaviour
{
    public TextMeshProUGUI optionText;
    private string emptyInfoText = "";
    public TMP_Dropdown dropdown;
    void OnEnable()
    {
        dropdown.onValueChanged.AddListener(OnDropdownValueChange);
        dropdown.value = 0;
    }
    void OnDropdownValueChange(int index)
    {
        optionText.text = dropdown.options[index].text;
    }
    void OnDisable()
    {
        dropdown.onValueChanged.RemoveListener(OnDropdownValueChange);
        optionText.text = emptyInfoText;
    }
}
