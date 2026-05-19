using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;
    public GameObject endMenu;
    public GameObject defeat;


    bool isPaused = false;
    bool gameStarted = false;

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        Time.timeScale = 0f;
        startMenu.SetActive(true);
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        defeat.SetActive(false);

        UnlockCursor();
    }

    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        startMenu.SetActive(false);
        Time.timeScale = 1f;

        LockCursor();
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        UnlockCursor();
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        LockCursor();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void EndGame()
    {
        Time.timeScale = 0f;

        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        endMenu.SetActive(true);
        defeat.SetActive(false);

        isPaused = false;
        gameStarted = false;

        UnlockCursor();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;

        isPaused = false;
        gameStarted = true;

        startMenu.SetActive(false);
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
        defeat.SetActive(false);

        LockCursor();

        // Recarrega a cena atual
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void DefeatGame()
    {
        Time.timeScale = 0f;

        pauseMenu.SetActive(false);
        startMenu.SetActive(false);
        endMenu.SetActive(false);
        defeat.SetActive(true);

        isPaused = false;
        gameStarted = false;

        UnlockCursor();
    }
}