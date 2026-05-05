using UnityEngine;

public class InteracaoPapel : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            // Em 1ª pessoa, o laser sai do centro dos teus "olhos" (a câmara) e vai a direito!
            // Aumentei a distância para 4 metros para garantir que chega ao chão.
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out var hit, 4f))
            {
                // Isto vai escrever na consola exatamente onde o laser tocou!
                Debug.Log("tocaste no objeto: " + hit.collider.gameObject.name);

                if (hit.collider.TryGetComponent(out LerPapel papel))
                {
                    Debug.Log("PAPELLL");
                    papel.AbrirMensagem();
                }
            }
            else
            {
                Debug.Log(" tas a apontar para o ar.");
            }
        }
    }
}