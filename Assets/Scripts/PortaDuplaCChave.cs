using UnityEngine;

public class PortaDuplaComChave : MonoBehaviour
{
    [Header("Configurações do Inventário")]
    public Inventario mochilaDoJogador;
    public Sprite chaveNecessaria;

    [Header("Configurações das Portas")]
    public Transform portaDireita;
    public float anguloAberto = 90f;
    public float velocidade = 2f;

    public float distanciaInteracao = 3f;

    private bool isOpen = false;

    private Quaternion rotacaoFechadaEsq;
    private Quaternion rotacaoAbertaEsq;
    private Quaternion rotacaoFechadaDir;
    private Quaternion rotacaoAbertaDir;

    void Start()
    {
        rotacaoFechadaEsq = transform.localRotation;
        rotacaoAbertaEsq = Quaternion.Euler(0f, anguloAberto, 0f) * rotacaoFechadaEsq;

        if (portaDireita != null)
        {
            rotacaoFechadaDir = portaDireita.localRotation;
            rotacaoAbertaDir = Quaternion.Euler(0f, -anguloAberto, 0f) * rotacaoFechadaDir;
        }
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            isOpen ? rotacaoAbertaEsq : rotacaoFechadaEsq,
            Time.deltaTime * velocidade
        );

        if (portaDireita != null)
        {
            portaDireita.localRotation = Quaternion.Lerp(
                portaDireita.localRotation,
                isOpen ? rotacaoAbertaDir : rotacaoFechadaDir,
                Time.deltaTime * velocidade
            );
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && isOpen == false)
        {
            Ray raio = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(raio, out hit, distanciaInteracao))
            {
                
                if (hit.collider.gameObject == gameObject || (portaDireita != null && hit.collider.gameObject == portaDireita.gameObject))
                {
                    if (mochilaDoJogador.TemItem(chaveNecessaria))
                    {
                        AbrirPortas();
                    }
                    else
                    {
                        Debug.Log("As portas estão trancadas! Precisas da chave.");
                    }
                }
            }
        }
    }

    void AbrirPortas()
    {
        isOpen = true;
        Debug.Log("As portas abriram com a chave!");

        // --- ADICIONA ISTO AQUI ---
        // Gasta a chave, removendo-a da mochila!
        if (mochilaDoJogador != null)
        {
            mochilaDoJogador.RemoverItem(chaveNecessaria);
        }
    }
}