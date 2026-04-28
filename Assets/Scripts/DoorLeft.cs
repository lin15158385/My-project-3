using UnityEngine;
using TMPro;

public class DoorLeft : MonoBehaviour
{
    public float anguloAberto = 90f;
    public float velocidade = 2f;
    public float distanciaInteracao = 2.5f;
    public doorRight portaDireita;
    

    private bool isOpen = false;
    private Transform jogador;
    private Quaternion rotacaoFechada;
    private Quaternion rotacaoAberta;
    private BoxCollider boxCollider;

    void Start()
    {
        rotacaoFechada = transform.localRotation;
        rotacaoAberta = Quaternion.Euler(0f, anguloAberto, 0f) * rotacaoFechada;
        jogador = Camera.main.transform;
        

        boxCollider = GetComponentInChildren<BoxCollider>();
    }
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);

        if (distancia <= distanciaInteracao)
        {
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpen = !isOpen;
                boxCollider.enabled = !isOpen;

                if (isOpen)
                    portaDireita.Abrir();
                else
                    portaDireita.Fechar();
            }
        }
        else
        {
            
        }

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            isOpen ? rotacaoAberta : rotacaoFechada,
            Time.deltaTime * velocidade
        );
    }
}
