using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public TMP_InputField inputTitle;
    public TMP_InputField intputText;
    private string emptyText = "";
    void OnEnable()
    {
        inputTitle.text = emptyText;
        intputText.text = emptyText;
    }
}
