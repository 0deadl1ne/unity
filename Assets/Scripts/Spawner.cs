using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Buuble;

    public float TimeSpawn;

  
    void Start()
    {
        StartCoroutine(SpawnCD());
    }
    void Repeat()
    {
        StartCoroutine(SpawnCD());

    }

    
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
        //Instantiate(Buble, SpawnPos.position, Quaternion.identity);
        GameObject Buble = Instantiate(Buuble, SpawnPos.position, Quaternion.identity);
        Destroy(Buble, 10f);
        Repeat();

        


    }
}
