using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitToSpawn;
    public GameObject bomb;
    public Transform[] spawnPlaces;
    public float minWaitTime = 0.3f;
    public float maxWaitTime = 1f;
    public float minForce = 10f;
    public float maxForce = 15f;
    void Start()
    {
        StartCoroutine("SpawnedFruits");
    }

    private IEnumerator SpawnedFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
            int objProbability = Random.Range(0, 100);
            GameObject objToSpawn = null;
            if (objProbability < 10)
            {
                objToSpawn = bomb;
            }
            else
            {
                objToSpawn = fruitToSpawn[Random.Range(0, fruitToSpawn.Length)];
            }
            GameObject fruits = Instantiate(objToSpawn, t.transform.position, t.transform.rotation) as GameObject; // to add to a list to delete
            fruits.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Destroy(fruits.gameObject, 5f);

        }
    }
}
