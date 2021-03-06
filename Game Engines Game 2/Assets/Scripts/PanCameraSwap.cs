﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCameraSwap : MonoBehaviour
{
    public float timeRemaining = 6;
    public bool timerIsRunning = false;
    public GameObject panCamera;
    public GameObject SidePanCamera;

    public Transform[] waypointRoutes;
    public Transform target;
    private int route;
    public float param;
    private Vector3 fighterPosition;
    public float speedModifier = 0.25f;
    private bool courtuneOn;

    private void OnEnable()
    {
        route = 0;
        param = 0f;
        courtuneOn = true;
        StartCoroutine(StartRoute(route));
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                SidePanCamera.SetActive(true);
                panCamera.SetActive( false);
                
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        transform.LookAt(target);

    }
    public IEnumerator StartRoute(int routeNumber)
    {
        courtuneOn = false;
        Vector3 p0 = waypointRoutes[routeNumber].GetChild(0).position;
        Vector3 p1 = waypointRoutes[routeNumber].GetChild(1).position;
        Vector3 p2 = waypointRoutes[routeNumber].GetChild(2).position;
        Vector3 p3 = waypointRoutes[routeNumber].GetChild(3).position;

        while (param< 1)
        {
                param += Time.deltaTime* speedModifier;

                fighterPosition = Mathf.Pow(1 - param, 3) * p0 +
                3 * Mathf.Pow(1 - param, 2) * param* p1 +
                3 * (1 - param) * Mathf.Pow(param, 2) * p2 +
                Mathf.Pow(param, 3) * p3;
          
            //transform.LookAt(transform.position);
            transform.position = fighterPosition;
            yield return new WaitForEndOfFrame();
        }
    }
}
