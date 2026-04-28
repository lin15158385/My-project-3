using UnityEngine;

public class doorRight : MonoBehaviour
{
    public float anguloAberto = 90f;
    public float velocidade = 2f;

    private bool isOpen = false;
    private Quaternion rotacaoFechada;
    private Quaternion rotacaoAberta;
    private BoxCollider boxCollider;

    void Start()
    {
        rotacaoFechada = transform.localRotation;
        rotacaoAberta = Quaternion.Euler(0f, -anguloAberto, 0f) * rotacaoFechada;
       

        boxCollider = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            isOpen ? rotacaoAberta : rotacaoFechada,
            Time.deltaTime * velocidade
        );
    }

    public void Abrir()
    {
        isOpen = true;
        boxCollider.enabled = false;
    }

    public void Fechar()
    {
        isOpen = false;
        boxCollider.enabled = true;
    }
}
