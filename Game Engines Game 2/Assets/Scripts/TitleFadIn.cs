using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleFadIn : MonoBehaviour
{
    public float timer = 10;
    public float speed = 5f;
    public Image fadIn;
    public bool stopTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        // fadIn.canvasRenderer.SetAlpha(0f);
        Color color = fadIn.color;
        color.a = 0f;
        fadIn.color = color;
        speed = GetComponentInParent<Canvas>().transform.lossyScale.y * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        timer -= Time.deltaTime;

        if (timer <= 0 && !stopTimer)
        {
            StartCoroutine("Fade");
            stopTimer = true;
        }
    }

    IEnumerator Fade()
    {
        // fadIn.CrossFadeAlpha(1, 5, false);
        // yield return new WaitForSeconds(20f);
        while (fadIn.color.a < 1F)
        {
            Color col = fadIn.color;
            col.a += Time.deltaTime * 0.2f;
            fadIn.color = col;
            yield return null;
        }

        Color color = fadIn.color;
        color.a = 1f;
        fadIn.color = color;
        SceneManager.LoadScene(1);
    }
}
