using UnityEngine;

public class EndGame : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<MenuManager>().EndGame();
        }
    }
}
