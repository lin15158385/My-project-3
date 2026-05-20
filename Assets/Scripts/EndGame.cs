using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 1. Manda o relógio guardar o tempo gasto
            HourTimer relogio = FindFirstObjectByType<HourTimer>();
            if (relogio != null)
            {
                relogio.GuardarTempoVitoria(); // Usamos aquela função que já tinhas no Timer!
            }

            // 2. Manda o MenuManager abrir o Canvas de vitória
            MenuManager menu = FindFirstObjectByType<MenuManager>();
            if (menu != null)
            {
                menu.EndGame();
            }
        }
    }
}