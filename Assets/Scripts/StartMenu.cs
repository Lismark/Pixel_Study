using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelection;
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject selectLevelButton;
    private Scene currentLevel;
    private LoadSceneParameters loadParameters = new LoadSceneParameters(LoadSceneMode.Additive);

    public void OnPlayButtonClick()
    {
        if(levelSelection != null)
        levelSelection.SetActive(true);

        if (menuButtons != null)
            menuButtons.SetActive(false);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnClickFacebook()
    {
        Application.OpenURL("https://www.facebook.com/markeslys");
        Debug.Log("GoToFacebook");
    }
    public void CloseLvlSelect()
    {
        if (levelSelection != null)
            levelSelection.SetActive(false);

        if (menuButtons != null)
            menuButtons.SetActive(true);
    }
    public void LvlStart(int index)
    {
        Time.timeScale = 1;

        if (currentLevel.isLoaded)
            SceneManager.UnloadSceneAsync(currentLevel);
        currentLevel = SceneManager.LoadScene($"lvl_{index}", loadParameters);

        if (menuCanvas != null)
        menuCanvas.SetActive(false);

        if (levelSelection != null)
            levelSelection.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);
    }
    public void onClickPause()
    {
        Time.timeScale = 0;
        if (menuCanvas != null)
            menuCanvas.SetActive(true);

        if (resumeButton != null)
            resumeButton.SetActive(true);
        gameObject.SetActive(false);

        if (menuButtons != null)
            menuButtons.SetActive(true);

        if(playButton !=null)
        playButton.SetActive(false);

        if (selectLevelButton != null)
            selectLevelButton.SetActive(true);

    }
    public void OnclickResume()
    {
        Time.timeScale = 1;
        if (menuCanvas != null)
            menuCanvas.SetActive(false);

        if (pauseButton != null)
            pauseButton.SetActive(true);
    }
    public void onSelectLevel()
    {
        if (levelSelection != null)
        levelSelection.SetActive(true);
    }
}
