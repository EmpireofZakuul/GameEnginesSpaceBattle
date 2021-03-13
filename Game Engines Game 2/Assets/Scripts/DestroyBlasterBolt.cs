using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlasterBolt : MonoBehaviour
{
    public float speed = 20;
    public float destroy = 2f;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
       // Destroy(this.gameObject, destroy);
       
    }

    // Update is called once per frame
    void Update()
    {
        prefab.GetComponent<Rigidbody>().velocity = (transform.forward * speed);
    }
}
