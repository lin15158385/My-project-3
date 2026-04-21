using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject pauseMenu;

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

        UnlockCursor();
    }

    void Update()
    {
        if (!gameStarted) return;

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
}