using UnityEngine;
using TMPro;

public class ObjectDrag : MonoBehaviour
{
    public float distance = 3f;
    public float moveSpeed = 10f;

    public TextMeshProUGUI interactText;

    private GameObject currentObject;
    private Rigidbody currentRb;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // DETETAR OBJETO
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.CompareTag("Draggable"))
            {
                interactText.text = "E - Drag";
                interactText.enabled = true;
                Debug.Log("A olhar para: " + hit.collider.name);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentObject = hit.collider.gameObject;
                    currentRb = currentObject.GetComponent<Rigidbody>();
                }
            }
            else
            {
                interactText.enabled = false;
            }
        }
        else
        {
            interactText.enabled = false;
        }

        // ARRASTAR OBJETO
        if (currentObject != null)
        {
            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * 2f;
            currentRb.linearVelocity = (targetPosition - currentObject.transform.position) * moveSpeed;

            if (Input.GetKeyUp(KeyCode.E))
            {
                currentObject = null;
            }
        }
    }
}