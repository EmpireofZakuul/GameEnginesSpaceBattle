using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //public ParticleSystem particle;
    public GameObject particle;


    // Start is called before the first frame update
    void OnEnable()
    {
        //particle.Play();
        StartCoroutine(ShakeCamera(10, 0.02f));
        Destroy(particle,11f);
    }

    public IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 cameraOrginalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, cameraOrginalPos.z);

            elapsed += Time.deltaTime;

            yield return null;

        }
        transform.localPosition = cameraOrginalPos;
    }

    private void Update()
    {
        /*if (particle)
        {
            if (!particle.IsAlive())
            {
                Destroy(gameObject);
            }
        }
        */
    }
}
