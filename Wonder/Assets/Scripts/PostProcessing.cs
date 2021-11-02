using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume pp;
    public Transform player;

    private void Start()
    {
        StartCoroutine(LerpVignetteSlowTime(3, 5));
        StartCoroutine(ZoomTo(player.position));
    }

    IEnumerator LerpVignetteSlowTime(float delay, float newVignette)
    {
        yield return new WaitForSeconds(delay);
        Vignette vignette;
        pp.profile.TryGetSettings(out vignette);
        while (vignette.intensity.value <= 0.7)
        {
            yield return null;
            vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.7f, Time.deltaTime * newVignette);
        }
    }

    IEnumerator ZoomTo(Vector3 endPoint)
    {
        while (Vector3.Distance(transform.position, endPoint) > 0.5)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, endPoint, Time.deltaTime);
        }
    }
}
