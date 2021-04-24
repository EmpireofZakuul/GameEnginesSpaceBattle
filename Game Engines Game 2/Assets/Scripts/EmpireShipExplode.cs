using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipExplode : MonoBehaviour
{
    [Header("Enemy Explode")]
    public Transform effect;
    public bool explode = false;
    //public GameObject theObjectToBeUnParented;
    public GameObject destroy;
    public bool dead = false;
    [Header("Enemy Health")]
    public int maxHealth = 100;
    public int health;
    public float BlowRadius = 6f;
    private EternalFleet character;


    // Start is called before the first frame update
    void OnEnable()
    {

        health = maxHealth;

       GameObject.Find("ShipHolder").GetComponents<EternalFleet>();
       character = FindObjectOfType<EternalFleet>();
       character.isFound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !explode)
        {  
            explode = true;
            Dead();
        }

    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EternalEnemy")
        {
            TakeDamage(100);
        }


    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    public void Explode()
    {


        Collider[] coll = Physics.OverlapSphere(transform.position, BlowRadius);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<EternalFleet>())
            {
                character.TakeDamage(100);
            }
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, BlowRadius);
    }

    public void Dead()
    {
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(destroy,.5f);
    }
}
