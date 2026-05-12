using UnityEngine;
using System.Collections;

public class DarkRoomTrigger : MonoBehaviour
{
    public Color targetColor = Color.black;
    public float targetIntensity = 0.01f;
    public float transitionSpeed = 2f;

    private Coroutine currentRoutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTransition(targetColor, targetIntensity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartTransition(Color.gray, 1f);
        }
    }

    void StartTransition(Color color, float intensity)
    {
        if (currentRoutine != null)
            StopCoroutine(currentRoutine);

        currentRoutine = StartCoroutine(TransitionLighting(color, intensity));
    }

    IEnumerator TransitionLighting(Color targetColor, float targetIntensity)
    {
        Color startColor = RenderSettings.ambientLight;
        float startIntensity = RenderSettings.ambientIntensity;

        float time = 0;

        while (time < 1)
        {
            time += Time.deltaTime * transitionSpeed;

            RenderSettings.ambientLight =
                Color.Lerp(startColor, targetColor, time);

            RenderSettings.ambientIntensity =
                Mathf.Lerp(startIntensity, targetIntensity, time);

            yield return null;
        }
    }
}