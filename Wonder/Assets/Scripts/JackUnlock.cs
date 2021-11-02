using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JackUnlock : MonoBehaviour
{
    public Interactable interactable;
    private void Start()
    {
        GetComponent<RectTransform>().localScale = Vector3.zero;
        StartCoroutine(JackPopup());
    }

    IEnumerator JackPopup()
    {
        var rectTransform = GetComponent<RectTransform>();
        Vector3 desiredScale = new Vector3(2, 2, 2);
        while (rectTransform.localScale.magnitude <= desiredScale.magnitude)
        {
            yield return null;
            rectTransform.localScale =
                Vector3.Lerp(rectTransform.localScale, new Vector3(2.2f, 2.2f, 2.2f), Time.deltaTime);
        }

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scene6");
    }
}
