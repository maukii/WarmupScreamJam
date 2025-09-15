using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Canvas canvas;
    CanvasGroup canvasGroup;

    [Header("Menus:")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject exitGame;
    [SerializeField] MenuState state;


    enum MenuState
    {
        Main, Options, Exit
    }

    void Awake()
    {
        canvas = FindAnyObjectByType<Canvas>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();

    }
    void Start()
    {
        AudioManager.PlayMusic("MenuTheme");
    }

    public void StartGame()
    {
        SceneTransition();
    }
    public void Options()
    {
        state = MenuState.Options;
        MenuToggle();
    }
    public void Main()
    {
        state = MenuState.Main;
        MenuToggle();
    }
    public void MenuToggle()
    {
        if (state == MenuState.Main)
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (state == MenuState.Options)
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
        else if (state == MenuState.Exit)
        {
            optionsMenu.SetActive(false);
            mainMenu.SetActive(false);
            exitGame.SetActive(true);
        }
    }
    public void ExitGame()
    {
        //Application.Quit();
        state = MenuState.Exit;
        MenuToggle();
        AudioManager.StopMusic();
    }

    public void SceneTransition()
    {
        Coroutine fadeToBlack = StartCoroutine(FadeToBlack());

    }
    IEnumerator FadeToBlack()
    {
        while (0 < canvasGroup.alpha)
        {
            canvasGroup.alpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("Gameplay");
    }
}
