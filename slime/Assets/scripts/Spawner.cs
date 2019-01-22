using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float spawnTime = 5f;       
    public float spawnDelay = 0;
    public GameObject enemy;
    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
