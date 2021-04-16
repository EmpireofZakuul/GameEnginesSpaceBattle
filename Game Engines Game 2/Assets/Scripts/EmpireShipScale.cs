using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipScale : MonoBehaviour
{
    public float time = 8f;
    public bool timeIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    public void Update()
    {
        if (timeIsRunning)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
                timeIsRunning = false;
                StartCoroutine(ScaleOverTime(3));
            }
        }
    }

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 destinationScale = new Vector3(1.0f, 1.0f, 1.0f);

        float currentTime = 0.0f;


        while (currentTime < time)
        {
            transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = destinationScale;

    }
}
