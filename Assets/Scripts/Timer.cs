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
    // --- NOVA FUNÇÃO PARA O TOP 3 HIGHSCORES ---
    public void GuardarTempoVitoria()
    {
        isRunning = false; // Pára o relógio

        // Calcula quanto tempo demoraste nesta run
        float tempoGasto = totalTime - timeRemaining;

        // Guarda o tempo DESTA RUN para o jogador ver o que acabou de fazer
        PlayerPrefs.SetString("TempoAtualTexto", FormatTime(tempoGasto));

        // 1. Carrega o Top 3 atual (Se estiver vazio, pomos um número gigante como 999999)
        float r1 = PlayerPrefs.GetFloat("Recorde_1_Segundos", 999999f);
        float r2 = PlayerPrefs.GetFloat("Recorde_2_Segundos", 999999f);
        float r3 = PlayerPrefs.GetFloat("Recorde_3_Segundos", 999999f);

        // 2. Lógica de Encaixe e "Empurrão" (Filtro do Top 3)
        if (tempoGasto < r1)
        {
            // O novo tempo é o melhor de sempre! Empurra todos para baixo
            r3 = r2;
            r2 = r1;
            r1 = tempoGasto;
        }
        else if (tempoGasto < r2)
        {
            // É melhor que o 2º lugar! Empurra o 2º para 3º
            r3 = r2;
            r2 = tempoGasto;
        }
        else if (tempoGasto < r3)
        {
            // Entra apenas para o 3º lugar
            r3 = tempoGasto;
        }

        // 3. Grava os novos valores numéricos na memória
        PlayerPrefs.SetFloat("Recorde_1_Segundos", r1);
        PlayerPrefs.SetFloat("Recorde_2_Segundos", r2);
        PlayerPrefs.SetFloat("Recorde_3_Segundos", r3);

        // 4. Grava os textos formatados (Se ainda for o valor inicial 999999, mostra "--:--:--")
        PlayerPrefs.SetString("Recorde_1_Texto", r1 < 999999f ? FormatTime(r1) : "--:--:--");
        PlayerPrefs.SetString("Recorde_2_Texto", r2 < 999999f ? FormatTime(r2) : "--:--:--");
        PlayerPrefs.SetString("Recorde_3_Texto", r3 < 999999f ? FormatTime(r3) : "--:--:--");

        // Salva tudo fisicamente no PC
        PlayerPrefs.Save();

        Debug.Log("Tabela de Highscores atualizada nos bastidores!");
        }
}