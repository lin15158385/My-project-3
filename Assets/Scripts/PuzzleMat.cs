using UnityEngine;
using TMPro;

public class PuzzleMat : MonoBehaviour
{
    [Header("Configurações")]
    public string respostaCorreta = "15";

    [Header("Objetos")]
    public TMP_InputField campoDeResposta;
    public GameObject alavancaSecreta;

    [Header("O Teu Script de Abrir/Fechar")]
    // Vamos chamar o teu script LerPapel para ele fechar o puzzle por nós!
    public LerPapel scriptDoPapel;

    public void VerificarResposta()
    {
        if (campoDeResposta.text == respostaCorreta)
        {
            Debug.Log("Acertou! A alavanca apareceu.");

            // 1. Mostra a alavanca
            if (alavancaSecreta != null)
                alavancaSecreta.SetActive(true);

            // 2. Usa o TEU script para fechar a interface e voltar a prender o rato!
            if (scriptDoPapel != null)
                scriptDoPapel.FecharMensagem();
        }
        else
        {
            Debug.Log("Errou!");
            campoDeResposta.text = ""; // Limpa a caixa para tentar de novo
        }
    }
}