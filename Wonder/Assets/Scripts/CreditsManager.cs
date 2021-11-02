using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Credits(90));
    }

    IEnumerator Credits(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("MainMenu");
    }
}
