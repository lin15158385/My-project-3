using UnityEngine;
using TMPro;

public class MostrarHighscore : MonoBehaviour
{
    public TextMeshProUGUI textoDoTempo;

    void Start()
    {
        // Vai procurar o texto que guardámos antes. Se não encontrar, escreve "Nenhum tempo"
        string tempoGuardado = PlayerPrefs.GetString("TempoEmTexto", "Nenhum tempo");

        textoDoTempo.text = "Tempo da última fuga: " + tempoGuardado;
    }
}