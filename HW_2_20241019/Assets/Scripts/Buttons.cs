using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button oneBtn;
    public Button twoBtn;
    public Button disableBtn;
    public TextMeshProUGUI infoText;
    private string emptyInfoText = "";
    void OnEnable()
    {
        oneBtn.onClick.AddListener(OnOneBtnClick);
        twoBtn.onClick.AddListener(OnTwoBtnClick);
        disableBtn.onClick.AddListener(OnDisableBtnClick);
    }
    public void OnOneBtnClick()
    {
        TextMeshProUGUI buttonText = oneBtn.GetComponentInChildren<TextMeshProUGUI>();
        infoText.text = buttonText.text + " Clicked";
    }
    public void OnTwoBtnClick()
    {
        TextMeshProUGUI buttonText = twoBtn.GetComponentInChildren<TextMeshProUGUI>();
        infoText.text = buttonText.text + " Clicked";
    }
    public void OnDisableBtnClick()
    {
        oneBtn.interactable = false;
        twoBtn.interactable = false;
        disableBtn.interactable = false;
        infoText.text = emptyInfoText;
        
    }
    void OnDisable()
    {
        bool btnsStatusCheck = oneBtn.interactable;
        if(!btnsStatusCheck)
        {
            oneBtn.interactable = true;
            twoBtn.interactable = true;
            disableBtn.interactable = true;
        }
        oneBtn.onClick.RemoveListener(OnOneBtnClick);
        twoBtn.onClick.RemoveListener(OnTwoBtnClick);
        disableBtn.onClick.RemoveListener(OnDisableBtnClick);
    }
}
