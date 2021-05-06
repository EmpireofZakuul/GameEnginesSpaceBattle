using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleet : MonoBehaviour
{

    /*
        [Header("Health")]
        public int maxHealth = 100;
        public int health;
        public bool explode = true;
        public Transform effect;

        */
    // public Transform cameraEnd;
    // public float speed = 1f;
    //public bool isFound;

    // Start is called before the first frame update
    // void Start()
    //{
    // health = maxHealth;
    // }

    // Update is called once per frame
    //void Update()
    //{

    // transform.position = Vector3.MoveTowards(transform.position, cameraEnd.position, speed * Time.deltaTime);

    // if (health <= 0 && explode)
    // {
    // Dead();
    // explode = false;
    //}
    // }
    //public void ChangeMaterial()
    //{

    // }

    // public void OnTriggerEnter(Collider other)
    //{
    // if (other.gameObject.tag == "EmpireEnemy")
    // {
    // TakeDamage(100);
    // }
    // }

    // public void TakeDamage(int damage)
    // {
    //  health -= damage;
    // }

    // public void Dead()
    //{

    // Instantiate(effect, transform.position, transform.rotation);
    // Destroy(gameObject, .5f);
    // }


    public Transform cameraEnd;
    public GameObject holder;
    public float speed = 600f;
    public FighterMovement movment;


    public void Update()
    {
        if (movment.eternalFleetMove == true)
        {
            holder.transform.position = Vector3.MoveTowards(holder.transform.position, cameraEnd.position, speed * Time.deltaTime);
        }
    }

}
