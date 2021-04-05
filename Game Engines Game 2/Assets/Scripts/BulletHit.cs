using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public Transform effect;
    public GameObject part;
    public AudioSource source;
    ObjectPool objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        objectPooler = ObjectPool.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    { 
        if ( other.gameObject.tag == "EmpireEnemy")
           // if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EmpireEnemy")
            {
            //Instantiate(effect, transform.position, transform.rotation);
            objectPooler.SpawnFromPool("Explosions", transform.position, transform.rotation);
            //objectPooler.ReturnToPool();
            part.SetActive(false);
            source.Play();
            part.SetActive(true);
        }
        
    }
}
