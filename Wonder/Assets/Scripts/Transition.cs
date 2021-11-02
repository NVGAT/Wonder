using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public float transitionTime;
    public string sceneToLoad;
    
    private void Awake()
    {
        StartCoroutine(TransitionTime(transitionTime));
    }

    private IEnumerator TransitionTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneToLoad);
    }
}
