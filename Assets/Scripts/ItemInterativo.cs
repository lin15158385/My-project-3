using UnityEngine;

public class ItemInterativo : MonoBehaviour
{
    private bool perto = false;

    // A imagem 2D deste item específico (que vai aparecer no inventário)
    public Sprite imagemDesteItem;

    // A referência à mochila do jogador
    public Inventario mochilaDoJogador;

    void Update()
    {
        if (perto == true && Input.GetKeyDown(KeyCode.E) || perto == true && Input.GetMouseButtonDown(0))
        {
            // Envia a imagem para a mochila
            mochilaDoJogador.AdicionarItem(imagemDesteItem);

            // Destrói o objeto 3D
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player")) perto = true;
    }

    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("Player")) perto = false;
    }
}