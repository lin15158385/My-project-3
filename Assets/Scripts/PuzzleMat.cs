using UnityEngine;
using TMPro;

public class PuzzleMatematica : MonoBehaviour
{
    [Header("Configurações")]
    public string respostaCorreta = "15";

    [Header("Objetos")]
    public TMP_InputField campoDeResposta;
    public GameObject alavancaSecreta;

    [Header("Script para Fechar o PC")]
    public LerPapel scriptDoPapel; // script que fecha a tela

    public void VerificarResposta()
    {
        
        if (campoDeResposta.text == respostaCorreta)
        {
            Debug.Log("Acertou! A alavanca apareceu.");

            // 1. Mostra a alavanca
            if (alavancaSecreta != null)
                alavancaSecreta.SetActive(true);

            // 2. FECHA A TELA AUTOMATICAMENTE AQUI!
            if (scriptDoPapel != null)
            {
                scriptDoPapel.FecharMensagem(); 
            }
        }
        else
        {
            Debug.Log("Errou!");
            campoDeResposta.text = ""; // da clear
        }
    }
}