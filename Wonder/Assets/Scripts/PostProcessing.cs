using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PostProcessing : MonoBehaviour
{
    public PostProcessVolume pp;
    public GameObject player;
    public GameObject[] textBoxes;

    private void Start()
    {
        StartCoroutine(LerpVignetteSlowTime(3, 5));
        StartCoroutine(FakeSloMo(3.5f, 3));
        StartCoroutine(TextRoutine(4, 0));
        StartCoroutine(Transition(10, "Transition6"));
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

    IEnumerator TextRoutine(float delay, int box)
    {
        yield return new WaitForSeconds(delay);
        textBoxes.ElementAt(box).gameObject.SetActive(true);
    }

    IEnumerator Transition(float delay, string scene)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    IEnumerator FakeSloMo(float delay, float amount)
    {
        yield return new WaitForSeconds(delay);
        var playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.playSound = false;
        playerMovement.movementSpeed /= amount;
        playerMovement.sprintSpeed /= amount;
    }
}
