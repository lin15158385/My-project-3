using UnityEngine;

public class LerPapel : MonoBehaviour
{
    public GameObject painelMensagemUI;

    public void AbrirMensagem()
    {
        painelMensagemUI.SetActive(true); // Abre o pop-up

        // --- A MAGIA DO RATO ---
        // Destranca o rato para o poderes mover pelo ecrã
        Cursor.lockState = CursorLockMode.None;
        // Torna a setinha do rato visível
        Cursor.visible = true;
    }

    public void FecharMensagem()
    {
        painelMensagemUI.SetActive(false); // Fecha o pop-up

        // --- VOLTAR AO NORMAL ---
        // Prende o rato no centro do ecrã
        Cursor.lockState = CursorLockMode.Locked;
        // Esconde o rato para jogares em 1ª pessoa
        Cursor.visible = false;
    }
}