using UnityEngine;
using TMPro;

public class HighscoreVitoria : MonoBehaviour
{
    [Header("Tempo da Jogada Atual")]
    public TextMeshProUGUI textoDoTempoAtual;

    [Header("Tabela do Top 3")]
    public TextMeshProUGUI textoPrimeiroLugar;
    public TextMeshProUGUI textoSegundoLugar;
    public TextMeshProUGUI textoTerceiroLugar;

    void OnEnable()
    {
        // 1. Mostra o tempo que o jogador fez nesta run específica
        string tempoDestaRun = PlayerPrefs.GetString("TempoAtualTexto", "00:00:00");
        if (textoDoTempoAtual != null)
        {
            textoDoTempoAtual.text = "O teu tempo: " + tempoDestaRun;
        }

        // 2. Carrega o Top 3 histórico da memória do PC
        string p1 = PlayerPrefs.GetString("Recorde_1_Texto", "--:--:--");
        string p2 = PlayerPrefs.GetString("Recorde_2_Texto", "--:--:--");
        string p3 = PlayerPrefs.GetString("Recorde_3_Texto", "--:--:--");

        // 3. Atualiza os textos correspondentes no ecrã
        if (textoPrimeiroLugar != null) textoPrimeiroLugar.text = "1º Lugar: " + p1;
        if (textoSegundoLugar != null) textoSegundoLugar.text = "2º Lugar: " + p2;
        if (textoTerceiroLugar != null) textoTerceiroLugar.text = "3º Lugar: " + p3;
    }
}