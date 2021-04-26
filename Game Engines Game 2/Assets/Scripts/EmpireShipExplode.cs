using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipExplode : MonoBehaviour
{
    [Header("Enemy Explode")]
    public Transform effect;
    public bool explode = false;
    public GameObject destroy;
    public bool dead = false;
 
    public float BlowRadius = 6f;
    private EternalFleetHealth character;
    public EmpireShipHealth EmpireShipHealth;


    // Start is called before the first frame update
    void start()
    {
        GameObject.Find("ShipHolder").GetComponents<EternalFleetHealth>();
        character = FindObjectOfType<EternalFleetHealth>();
        character.isFound = true;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EternalEnemy")
        {
            
            EmpireShipHealth.TakeDamage(1000);
          
            Explode();
        }


    }


    public void Explode()
    {


        Collider[] coll = Physics.OverlapSphere(transform.position, BlowRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<EternalFleet>())
            {
                character.TakeDamageEnemy(100);
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, BlowRadius);
    }

   
}
