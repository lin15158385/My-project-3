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

    // Mudei para "public" para poderes usar esta função na formatação da tabela de Highscore mais tarde
    public string FormatTime(float seconds)
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

    // --- NOVA FUNÇÃO PARA O HIGHSCORE ---
    public void GuardarTempoVitoria()
    {
        isRunning = false; // Pára o relógio

        // Guarda o valor numérico em segundos do tempo que SOBROU
        PlayerPrefs.SetFloat("TempoEmSegundos", timeRemaining);

        // Guarda o texto já formatado do tempo que SOBROU (ex: "0:45:10")
        PlayerPrefs.SetString("TempoEmTexto", FormatTime(timeRemaining));

        // Guarda as alterações fisicamente no PC/Telemóvel
        PlayerPrefs.Save();

        Debug.Log("Tempo restante guardado com sucesso! Sobrou: " + FormatTime(timeRemaining));
    }
}