using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delay; //time for spawner to begin spawning enemies
    public float interval; //time between spawns  --- we can make irregular if we want to
    public GameObject enemy; //enemy that spawner will spawn
    void Start()
    {
        InvokeRepeating("Spawn", delay, interval);
    }

    void Spawn()
    {
        Instantiate(enemy, this.transform);
    }
}
