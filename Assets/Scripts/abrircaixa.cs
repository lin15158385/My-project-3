using UnityEngine;

public class abrircaixa : MonoBehaviour
{
    [Header("Referências")]
    public GameObject chave;
    public Animator animatorCaixa;

    private bool aberta = false;

    void Start()
    {
        // Chave inacessível no início
        chave.SetActive(false);
    }

    // Chama este método quando o jogador interagir com a caixa
    public void AbrirCaixa()
    {
        if (aberta) return;

        aberta = true;

        // Toca animação de abrir (se tiveres)
        if (animatorCaixa)
            animatorCaixa.SetTrigger("Abrir");

        // Ativa o collider da chave — agora pode ser apanhada


        chave.SetActive(true);

        Debug.Log("Caixa aberta! Chave disponível.");
    }
}
