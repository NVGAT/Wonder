using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TitleScreenDummy : MonoBehaviour
{
    public Transform[] startNodes;
    public Transform[] endNodes;
    public bool moving;
    public float movementTime;

    private void Update()
    {
        if (!moving)
        {
            moving = true;
            int timeToWait = Random.Range(0, 3);
            StartCoroutine(Move(timeToWait));
        }
    }

    IEnumerator Move(int time)
    {
        yield return new WaitForSeconds(time);
        float currentMovementTime = 0;
        int startPoint = Random.Range(0, endNodes.Length);
        transform.position = endNodes.ElementAt(startPoint).position;
        int endPoint = Random.Range(0, startNodes.Length);
        while (Vector2.Distance(transform.localPosition, startNodes.ElementAt(endPoint).position) > 0.5)
        {
            print("moving");
            currentMovementTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(transform.position, startNodes.ElementAt(endPoint).position,
                currentMovementTime / movementTime);
            yield return null;
        }
        moving = false;
    }
}
