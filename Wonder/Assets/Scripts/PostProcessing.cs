using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume pp;
    public GameObject player;

    private void Start()
    {
        StartCoroutine(LerpVignetteSlowTime(3, 5));
        StartCoroutine(FakeSloMo(3.5f, 3));
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
            print("lerping");
        }
    }

    IEnumerator FakeSloMo(float delay, float amount)
    {
        yield return new WaitForSeconds(delay);
        var playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.movementSpeed /= amount;
        playerMovement.sprintSpeed /= amount;
    }
}
