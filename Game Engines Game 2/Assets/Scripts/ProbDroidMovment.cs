using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbDroidMovment : MonoBehaviour
{
    public Transform cameraEnd;
    public GameObject holder;
    public float speed = 600f;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            holder.transform.position = Vector3.MoveTowards(holder.transform.position, cameraEnd.position, speed * Time.deltaTime);

        Destroy(holder, 40f);
    }
}
