using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpireShipHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public bool explode = true;
    public Transform effect;
    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && explode)
        {
            Dead();
            explode = false;
        }

        //if ( !explode)//testing
        //{
        //    Dead();
        //    explode = true;
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(7);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Dead()
    {
       
        Instantiate(effect, transform.position, transform.rotation);
        game.shipCounter--;
        Destroy(gameObject, .5f);
    }
}
