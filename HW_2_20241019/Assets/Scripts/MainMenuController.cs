using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public TextMeshProUGUI mainMenuText;
    public TextMeshProUGUI infoText;    
    private string mainMenuTitle = "Main Menu";
    public Button backToMainMenu;
    public GameObject buttonsPanel;
    public GameObject togglesPanel;
    public GameObject dropsPanel;
    public GameObject inputPanel;
    public GameObject scrollViewPanel;
    public void ShowMenu(GameObject menuToShow)
    {
        mainMenuPanel.SetActive(false);
        buttonsPanel.SetActive(false);
        togglesPanel.SetActive(false);
        dropsPanel.SetActive(false);
        inputPanel.SetActive(false);
        scrollViewPanel.SetActive(false);
        menuToShow.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
    }
    public void UpdateHeader(Button button)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        mainMenuText.text = buttonText.text;
    }

    public void ReturnToMainMenu()
    {
        buttonsPanel.SetActive(false);
        togglesPanel.SetActive(false);
        dropsPanel.SetActive(false);
        inputPanel.SetActive(false);
        scrollViewPanel.SetActive(false);
        backToMainMenu.gameObject.SetActive(false);
        mainMenuPanel.SetActive(true);
        mainMenuText.text = mainMenuTitle;
        infoText.text = "";                
    }


}
