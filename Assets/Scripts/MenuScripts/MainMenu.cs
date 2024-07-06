using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator _mainMenuAnimator;
    [SerializeField] private Animator _chooseGameModeAnimator;
    [SerializeField] private Animator _chooseTeamMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        _mainMenuAnimator.SetBool("IsOpen", true);
    }

    public void CloseMainMenu()
    {
        _mainMenuAnimator.SetBool("IsOpen", false);
    }

    public void OpenChooseModeMenu()
    {
        _chooseGameModeAnimator.SetBool("Open", true);
        _chooseGameModeAnimator.SetBool("CloseRight", false);
        _chooseGameModeAnimator.SetBool("CloseLeft", false);
    }

    public void CloseRightChooseModeMenu()
    {
        _chooseGameModeAnimator.SetBool("Open", false);
        _chooseGameModeAnimator.SetBool("CloseRight", true);
    }

    public void CloseLeftChooseModeMenu()
    {
        _chooseGameModeAnimator.SetBool("Open", false);
        _chooseGameModeAnimator.SetBool("CloseLeft", true);
    }

    public void StartLocalGame()
    {
        DataHolder.Mode = GameMode.PlayerVSPlayer;
        SceneManager.LoadScene("Game");
    }

    public void StartComputerGame(bool IsAiX)
    {
        DataHolder.Mode = GameMode.PlayerVSComputer;
        DataHolder.IsAiX = IsAiX;
        SceneManager.LoadScene("Game");
    }

    public void OpenChooseTeamMenu()
    {
        _chooseTeamMenu.SetBool("IsOpen", true);
    }

    public void CloseChooseTeamMenu()
    {
        _chooseTeamMenu.SetBool("IsOpen", false);
    }
}
