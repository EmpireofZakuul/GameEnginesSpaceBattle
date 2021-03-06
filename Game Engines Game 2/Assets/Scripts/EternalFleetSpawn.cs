﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EternalFleetSpawn : MonoBehaviour
{
    public Transform ship;
    public Transform shipParent;
    public Transform shipStartPos;

    public int numberOfRows;
    public int numberOfColumns;
    public int numberOfBobjectsPerRow;
    public int amountOfSpaceBetweenObject;

    public EternalFleetFire[,] eternalFleet;
    // Start is called before the first frame update

  
    public static EternalFleetSpawn Instance;
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

        /* for (int row = 0; row < numberOfRows; row++)
         {
             for (int i = 0; i < numberOfColumns; i++)
             {

                 Vector3 StartPos = new Vector3(shipStartPos.position.x, shipStartPos.position.y + row * amountOfSpaceBetweenObject, shipStartPos.position.z - i * amountOfSpaceBetweenObject);
                 Transform _ship = Instantiate(ship, StartPos, Quaternion.Euler(90, 180, 0));
                 _ship.SetParent(shipParent);

                 if (row != 0)
                 {
                     Vector3 StartPosi = new Vector3(shipStartPos.position.x, shipStartPos.position.y - row * amountOfSpaceBetweenObject, shipStartPos.position.z - i * amountOfSpaceBetweenObject);
                     Transform _shipi = Instantiate(ship, StartPosi, Quaternion.Euler(90, 180, 0));
                     _shipi.SetParent(shipParent);
                 }
                 if (i != 0)
                 {
                     Vector3 StartPosition = new Vector3(shipStartPos.position.x, shipStartPos.position.y + row * amountOfSpaceBetweenObject, shipStartPos.position.z + i * amountOfSpaceBetweenObject);
                     Transform _ships = Instantiate(ship, StartPosition, Quaternion.Euler(90, 180, 0));
                     _ships.SetParent(shipParent);

                     if (row != 0)
                     {
                         Vector3 StartPosi = new Vector3(shipStartPos.position.x, shipStartPos.position.y - row * amountOfSpaceBetweenObject, shipStartPos.position.z + i * amountOfSpaceBetweenObject);
                         Transform _shipis = Instantiate(ship, StartPosi, Quaternion.Euler(90, 180, 0));
                         _shipis.SetParent(shipParent);
                     }
                 }
             }
         }
        */



        SpawnShips();


    }

    private void SpawnShips()
    {
        eternalFleet = new EternalFleetFire[numberOfRows, numberOfColumns];
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < numberOfColumns; col++)
            {
                Vector3 StartPosi = new Vector3(shipStartPos.position.x, shipStartPos.position.y + row * amountOfSpaceBetweenObject, shipStartPos.position.z + col * amountOfSpaceBetweenObject);
                EternalFleetFire ship = Instantiate(this.ship, StartPosi, Quaternion.Euler(90, 180, 0)).GetComponentInChildren<EternalFleetFire>();
                ship.transform.root.SetParent(shipParent);
                eternalFleet[row, col] = ship;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
