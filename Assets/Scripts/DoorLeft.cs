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
        // A porta continua se movendo suavemente dependendo se isOpen é true ou false
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            isOpen ? rotacaoAberta : rotacaoFechada,
            Time.deltaTime * velocidade
        );
    }

    // O script do Keypad vai chamar esta função quando a senha estiver certa!
    public void Abrir()
    {
        isOpen = true;
        if (boxCollider != null) boxCollider.enabled = false;

        // Manda a porta direita abrir junto
        if (portaDireita != null) portaDireita.Abrir();
    }

    public void Fechar()
    {
        isOpen = false;
        if (boxCollider != null) boxCollider.enabled = true;

        // Manda a porta direita fechar junto
        if (portaDireita != null) portaDireita.Fechar();
    }
}
