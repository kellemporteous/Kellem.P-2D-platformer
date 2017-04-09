using UnityEngine;
using System.Collections;

public class Enemy_Spawner : MonoBehaviour {

    public GameObject enemy;
    public Transform[] spawnPoints;


    void Awake()
    {
        Spawn();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Spawn()
    {
        Instantiate(enemy, spawnPoints[0].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[1].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[2].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[3].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[4].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[5].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[6].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[7].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[8].transform.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemy, spawnPoints[9].transform.position, Quaternion.Euler(0, 0, 0));


    }
}
