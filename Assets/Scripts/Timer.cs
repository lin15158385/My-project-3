using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HourTimer : MonoBehaviour
{
    public float totalTime = 3600f;
    public TextMeshProUGUI timerText;
    public MenuManager menuManager;


    float timeRemaining;
    bool isRunning;

    void Start()
    {
        timeRemaining = totalTime;
        isRunning = true;
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            isRunning = false;
            UpdateUI();
            menuManager.DefeatGame();
            Debug.Log("Tempo esgotado!");

            return;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = FormatTime(timeRemaining);

        
    }

    string FormatTime(float seconds)
    {
        int h = Mathf.FloorToInt(seconds / 3600f);
        int m = Mathf.FloorToInt((seconds % 3600f) / 60f);
        int s = Mathf.FloorToInt(seconds % 60f);
        return string.Format("{0}:{1:00}:{2:00}", h, m, s);
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        timeRemaining = totalTime;
        isRunning = true;
        UpdateUI();
    }

    
}
