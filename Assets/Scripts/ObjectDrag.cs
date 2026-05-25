using UnityEngine;
using TMPro;

public class ObjectDrag : MonoBehaviour
{
    [Header("Configurações de Distância e Força")]
    public float interactionDistance = 3f;
    public float holdDistance = 2f;
    public float moveSpeed = 10f;

    [Header("UI")]
    public TextMeshProUGUI interactText;

    // Boa prática: definir a câmera no Inspector ou buscar no Start
    [SerializeField] private Camera mainCamera;

    private GameObject currentObject;
    private Rigidbody currentRb;

    // Variáveis para guardar o estado original do Rigidbody
    private bool originalGravity;
    private float originalDrag;

    void Start()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        if (interactText != null) interactText.enabled = false;
    }

    void Update()
    {
        // Só fazemos o Raycast se NÃO estivermos segurando um objeto
        if (currentObject == null)
        {
            HandleRaycast();
        }
        else
        {
            // Ocultar texto enquanto segura
            if (interactText != null) interactText.enabled = false;

            // Checar input de soltar o objeto (Botão Direito = 1)
            if (Input.GetMouseButtonUp(0))
            {
                DropObject();
            }
        }
    }

    void FixedUpdate()
    {
        // Toda alteração física constante deve ficar no FixedUpdate
        MoveObject();
    }

    private void HandleRaycast()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Draggable"))
            {
                interactText.text = "  [LMB] Arrastar";
                interactText.fontSize = 25;
                interactText.enabled = true;    

                // Segurar objeto com o botão esquerdo do rato (0)
                if (Input.GetMouseButtonDown(0))
                {
                    PickUpObject(hit.collider.gameObject);
                }
            }
           
        }
        else
        {
            interactText.enabled = false;
        }
    }

    private void PickUpObject(GameObject obj)
    {
        currentObject = obj;
        currentRb = currentObject.GetComponent<Rigidbody>();

        if (currentRb != null)
        {
            // Salva as configurações antigas
            originalGravity = currentRb.useGravity;
            originalDrag = currentRb.linearDamping; // Usando linearDamping (novo nome para "drag" no Unity 6+)

            // Prepara o objeto para ser carregado suavemente
            currentRb.useGravity = false;
            currentRb.linearDamping = 10f; // Evita que ele balance muito
        }
    }

    private void DropObject()
    {
        if (currentRb != null)
        {
            // Devolve as características originais ao soltar
            currentRb.useGravity = originalGravity;
            currentRb.linearDamping = originalDrag;
        }

        currentObject = null;
        currentRb = null;
    }

    private void MoveObject()
    {
        if (currentObject != null && currentRb != null)
        {
            // Calcula o ponto alvo na frente da câmera
            Vector3 targetPosition = mainCamera.transform.position + mainCamera.transform.forward * holdDistance;

            // Move o objeto em direção ao alvo
            Vector3 moveDirection = targetPosition - currentObject.transform.position;

            // Nota: linearVelocity substituiu "velocity" nas versões mais recentes (Unity 2023+)
            currentRb.linearVelocity = moveDirection * moveSpeed;
        }
    }
}