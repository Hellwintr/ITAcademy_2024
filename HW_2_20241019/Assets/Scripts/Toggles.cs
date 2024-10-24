using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{
    public Button firstBtn;
    public Image firstBtnChecked;
    public Button secondBtn;
    public Image secondBtnChecked;
    public Button thirdBtn;
    public Image thirdBtnChecked;
    public TextMeshProUGUI infoText;
    private TextMeshProUGUI buttonText;
    private string emptyInfoText = "";
    void OnFirstButtonClick() => OnButtonClick(1);
    void OnSecondButtonClick() => OnButtonClick(2);
    void OnThirdButtonClick() => OnButtonClick(3);
    void OnEnable()
    {
        firstBtn.onClick.AddListener(OnFirstButtonClick);
        secondBtn.onClick.AddListener(OnSecondButtonClick);
        thirdBtn.onClick.AddListener(OnThirdButtonClick);
        UncheckAllBtns();
    }
    private void OnButtonClick(int buttonIndex)
    {
        UncheckAllBtns();
        switch(buttonIndex)
        {
            case 1:
            firstBtnChecked.gameObject.SetActive(true);
            buttonText = firstBtn.GetComponentInChildren<TextMeshProUGUI>();
            infoText.text = buttonText.text + " Checked";
            break;
            case 2:
            secondBtnChecked.gameObject.SetActive(true);
            buttonText = secondBtn.GetComponentInChildren<TextMeshProUGUI>();
            infoText.text = buttonText.text + " Checked";
            break;
            case 3:
            thirdBtnChecked.gameObject.SetActive(true);
            buttonText = thirdBtn.GetComponentInChildren<TextMeshProUGUI>();
            infoText.text = buttonText.text + " Checked";
            break;
        }
    }
    void UncheckAllBtns()
    {
        firstBtnChecked.gameObject.SetActive(false);
        secondBtnChecked.gameObject.SetActive(false);
        thirdBtnChecked.gameObject.SetActive(false);
    }
    void OnDisable()
    {
        firstBtn.onClick.RemoveListener(OnFirstButtonClick);
        secondBtn.onClick.RemoveListener(OnSecondButtonClick);
        thirdBtn.onClick.RemoveListener(OnThirdButtonClick);
        UncheckAllBtns();
        infoText.text = emptyInfoText;
    }

}
