using UnityEngine;

public class ParedeDeslizante : MonoBehaviour
{
    public Vector3 distanciaDoMovimento = new Vector3(3f, 0f, 0f);
    public float velocidade = 2f;

    private bool isOpen = false;
    private Vector3 posicaoFechada;
    private Vector3 posicaoAberta;

    void Start()
    {
        // Mudámos de localPosition para position
        posicaoFechada = transform.position;
        posicaoAberta = posicaoFechada + distanciaDoMovimento;
    }

    void Update()
    {
        // Mudámos de localPosition para position
        transform.position = Vector3.Lerp(
            transform.position,
            isOpen ? posicaoAberta : posicaoFechada,
            Time.deltaTime * velocidade
        );
    }

    public void Abrir()
    {
        isOpen = true;
        Debug.Log("A parede secreta começou a mover-se!");
    }
}