using UnityEngine;

public class ApanharChave : MonoBehaviour
{
    private bool pertoDaChave = false;

    // Esta variável vai guardar o teu desenho da chave no ecrã
    public GameObject iconeChaveUI;

    void Start()
    {
        // Garante que o desenho começa escondido quando o jogo arranca
        if (iconeChaveUI != null)
        {
            iconeChaveUI.SetActive(false);
        }
    }

    void Update()
    {
        // Se o jogador estiver perto E carregar na tecla E
        if (pertoDaChave == true && Input.GetKeyDown(KeyCode.E))
        {
            // Mostra o ícone no ecrã
            if (iconeChaveUI != null)
            {
                iconeChaveUI.SetActive(true);
            }

            // Destrói a chave 3D que está no chão
            Destroy(gameObject);
        }
    }

    // Quando o jogador entra na zona da chave
    private void OnTriggerEnter(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            pertoDaChave = true;
        }
    }

    // Quando o jogador sai da zona da chave
    private void OnTriggerExit(Collider outro)
    {
        if (outro.CompareTag("Player"))
        {
            pertoDaChave = false;
        }
    }
}