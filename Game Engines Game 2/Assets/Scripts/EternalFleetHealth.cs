using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleetHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int health;
    public bool explode;
    public Transform effect;
    public bool isFound;
    // Start is called before the first frame update
    void OnEnable()
    {
        health = maxHealth;
        explode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && explode)
        {
            Dead();
            explode = false;
        }
    }
    public void TakeDamageEnemy(int damage)
    {
        health -= damage;
    }

    public void Dead()
    {

        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
      
    }
}
