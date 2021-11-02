using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public float distanceNeeded;
    public Transform player;
    public float dist;
    public GameObject[] textBubble;
    public GameObject summer;
    public string methodToRun;
    public bool active = true;

    private void Update()
    {
        dist = Vector2.Distance(transform.position, player.position);
        if (dist < distanceNeeded && active)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke(methodToRun, 0f);
            }
        }
        else if (dist > distanceNeeded && active)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
    }

    void DeactivateInteractable()
    {
        active = false;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
    }

    void Scene1MomTalk()
    {
        textBubble.ElementAt(0).gameObject.SetActive(true);
        DeactivateInteractable();
    }

    void Scene2()
    {
        DeactivateInteractable();
        textBubble.ElementAt(0).gameObject.SetActive(true);
        StartCoroutine(TransitionWait(10, "Transition2"));
    }

    void Scene3()
    {
        DeactivateInteractable();
        textBubble.ElementAt(0).gameObject.SetActive(true);
        StartCoroutine(TextRoutine(0, 0));
        StartCoroutine(TextRoutine(3, 1));
        StartCoroutine(TextRoutine(6, 2));
        StartCoroutine(TextRoutine(9, 3));
        StartCoroutine(TextRoutine(12, 4));
        StartCoroutine(TextRoutine(15, 5));
        StartCoroutine(TransitionWait(18, "Transition3"));
    }

    void Scene4()
    {
        DeactivateInteractable();
        StartCoroutine(TextRoutine(0, 0));
        StartCoroutine(SummerRoutine(5));
        StartCoroutine(TextRoutine(15, 1));
        StartCoroutine(TextRoutine(18, 2));
        StartCoroutine(TextRoutine(21, 3));
        StartCoroutine(TextRoutine(24, 4));
        StartCoroutine(TextRoutine(27, 5));
        StartCoroutine(TextRoutine(30, 6));
        StartCoroutine(TextRoutine(33, 7));
        StartCoroutine(HideAllAfterTime(38));
        StartCoroutine(TransitionWait(43, "Transition4"));
    }

    void Scene5()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        DeactivateInteractable();
        for (int i = 0; i < textBubble.Length; i++)
        {
            StartCoroutine(TextRoutine(5f * i, i));
        }

        StartCoroutine(TransitionWait(55, "Transition5"));
    }

    IEnumerator HideAllAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        foreach (GameObject textBox in textBubble)
        {
            textBox.gameObject.SetActive(false);
        }
    }

    public IEnumerator TextRoutine(float time, int textBox)
    {
        yield return new WaitForSeconds(time);
        if (textBox != 0)
        {
            textBubble.ElementAt(textBox - 1).gameObject.SetActive(false);
        }
        textBubble.ElementAt(textBox).gameObject.SetActive(true);
    }    
    
    IEnumerator SummerRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        while (Vector2.Distance(summer.transform.position, player.transform.position - new Vector3(0.2f, 0)) > 0.5)
        {
            summer.transform.position =
                Vector2.Lerp(summer.transform.position, player.transform.position, Time.deltaTime / 5);
            yield return null;
        }
        textBubble.ElementAt(1).gameObject.SetActive(true);
    }

    IEnumerator TransitionWait(float time, string scene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
