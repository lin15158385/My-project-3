using UnityEngine;

public class LerPapel : MonoBehaviour
{
    [Header("Arrasta o Painel_Mensagem para aqui")]
    public GameObject painel_mensagem_1sala;

    // Esta função deteta quando clicas no papel 3D com o rato
    void OnMouseDown()
    {
        // Se a distância for importante podes adicionar uma verificação aqui depois
        painel_mensagem_1sala.SetActive(true);
    }

    // Esta função vai ser chamada pelo botão "Fechar"
    public void FecharMensagem()
    {
        painel_mensagem_1sala.SetActive(false);
    }
}