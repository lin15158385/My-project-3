using UnityEngine;

public class Alavanca : MonoBehaviour
{
    [Header("O que esta alavanca faz?")]
    public ParedeDeslizante paredeSecreta;

    [Header("QUAL É A PEÇA QUE MEXE?")]
    public Transform pecaQueRoda; // <--- O SEGREDO ESTÁ AQUI

    [Header("Os Números Exatos (Copia do Transform)")]
    public Vector3 rotacaoFechada;
    public Vector3 rotacaoAberta;
    public float velocidade = 5f;

    private bool foiPuxada = false;
    private bool perto = false;

    void Update()
    {
        // Agora roda APENAS a peça que tu escolheste!
        if (pecaQueRoda != null)
        {
            Vector3 rotacaoDestino = foiPuxada ? rotacaoAberta : rotacaoFechada;

            pecaQueRoda.localRotation = Quaternion.Lerp(
                pecaQueRoda.localRotation,
                Quaternion.Euler(rotacaoDestino),
                Time.deltaTime * velocidade
            );
        }

        if (perto == true && (Input.GetKeyDown(KeyCode.E) || perto == true && Input.GetMouseButtonDown(0)))
        {
            Puxar();
        }
    }

    public void Puxar()
    {
        if (foiPuxada == false)
        {
            foiPuxada = true;
            Debug.Log("Alavanca puxada!");

            if (paredeSecreta != null)
            {
                paredeSecreta.Abrir();
            }
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