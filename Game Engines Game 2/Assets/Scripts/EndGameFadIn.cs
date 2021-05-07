using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameFadIn : MonoBehaviour
{
    public Image fadIn;
    public float timeRemaining = 44;
    public bool timerIsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        fadIn.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                StartCoroutine("Fade");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

    }
    IEnumerator Fade()
    {
        fadIn.CrossFadeAlpha(1, 5, false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
