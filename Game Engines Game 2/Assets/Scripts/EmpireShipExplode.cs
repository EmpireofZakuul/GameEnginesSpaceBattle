using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipExplode : MonoBehaviour
{

    public float BlowRadius = 6f;
   // private EternalFleetHealth character;
    public EmpireShipHealth EmpireShipHealth;
  
   


    // Start is called before the first frame update
    void OnEnable()
    {
        //GameObject.Find("Eternal Fleet2").GetComponents<EternalFleetHealth>();
        //eternalFleetHealth = FindObjectOfType<EternalFleetHealth>();
       // eternalFleetHealth.isFound = true;
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EternalEnemy" || other.gameObject.layer == 8)
        {
            Debug.Log("hit ship");
            EmpireShipHealth.TakeDamage(1000);
          
            Explode();
        }


    }


    public void Explode()
    {
        Debug.Log("Explode");

        Collider[] coll = Physics.OverlapSphere(transform.position, BlowRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<EternalFleetHealth>())
            {
                coll[i].gameObject.GetComponent<EternalFleetHealth>().TakeDamageEnemy(100);
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, BlowRadius);
    }

   
}
