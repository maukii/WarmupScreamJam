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
    [SerializeField] MenuState state;

    enum MenuState
    {
        Main, Options
    }

    void Awake()
    {
        canvas = FindAnyObjectByType<Canvas>();
        canvasGroup = canvas.GetComponent<CanvasGroup>();

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
        else
        {
            optionsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();

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
