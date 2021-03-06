﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public float timeRemaining = 3;
    public bool timerIsRunning = false;
    public bool go = false;

    public Image fadIn;

    public void Start()
    {
        //fadIn.canvasRenderer.SetAlpha(0f);
        Color color = fadIn.color;
        color.a = 0f;
        fadIn.color = color;
    }
    public void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                go = true;
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        if(movment.eternalFleetMove == true)
        {
            timerIsRunning = true;
        }

        if (go)
        {
            holder.transform.position = Vector3.MoveTowards(holder.transform.position, cameraEnd.position, speed * Time.deltaTime);
        }

        if (holder.transform.position == cameraEnd.position && go)
        {
            StartCoroutine("Fade");
            go = false;
        }

    }
    IEnumerator Fade()
    {
        // fadIn.CrossFadeAlpha(1, 5, false);
        // yield return new WaitForSeconds(20f);
        while (fadIn.color.a < 1F)
        {
            Color col = fadIn.color;
            col.a += Time.deltaTime * 0.02f;
            fadIn.color = col;
            yield return null;
        }

        Color color = fadIn.color;
        color.a = 1f;
        fadIn.color = color;
        SceneManager.LoadScene(3);
    }
    

}
