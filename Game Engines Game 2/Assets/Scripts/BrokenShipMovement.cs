using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector(0f, 5f);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

 


}
