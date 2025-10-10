using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject mainMenu;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
    
    }

    public void GotoOptionPanel()
    {
        optionPanel.SetActive(true);
        mainMenu.SetActive(false);

    }

    public void OptionCancelBtn()
    {
        optionPanel.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        // Application.Quit();
        Application.OpenURL("https://jayjay-cloud21.itch.io/flappybella");
    }
}
