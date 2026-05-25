using UnityEngine;

public class LerPapel : MonoBehaviour
{
    [Header("O Ecrã do PC")]
    public GameObject painelMensagemUI;

    [Header("Scripts do Jogador (Para Pausar)")]
    // Espaços para arrastarmos os controlos do jogador
    public MonoBehaviour movimentoDoJogador;
    public MonoBehaviour cameraDoJogador;

    public void AbrirMensagem()
    {
        painelMensagemUI.SetActive(true); // Abre o pop-up

        // 1. DESLIGA OS CONTROLOS DO JOGADOR
        if (movimentoDoJogador != null) movimentoDoJogador.enabled = false;
        if (cameraDoJogador != null) cameraDoJogador.enabled = false;

        // 2. SOLTA O RATO
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void FecharMensagem()
    {
        painelMensagemUI.SetActive(false); // Fecha o pop-up

        // 1. VOLTA A LIGAR OS CONTROLOS
        if (movimentoDoJogador != null) movimentoDoJogador.enabled = true;
        if (cameraDoJogador != null) cameraDoJogador.enabled = true;

        // 2. PRENDE O RATO
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}