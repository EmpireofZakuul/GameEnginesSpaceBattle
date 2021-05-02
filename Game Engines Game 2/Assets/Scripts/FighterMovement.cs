using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterMovement : MonoBehaviour
{
    public FighterSpawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Spawn").GetComponents<FighterSpawn>();
        spawn = FindObjectOfType<FighterSpawn>();
        spawn.isFound = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
