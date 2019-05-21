using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        GameObject slicedFruitInstance = Instantiate(slicedFruitPrefab, transform.position, transform.rotation) as GameObject;
        Rigidbody[] rbs = slicedFruitInstance.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(500, 1000), transform.position, 5f);
        }
        Destroy(gameObject);
        Destroy(slicedFruitInstance, 5f);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            CreateSlicedFruit();
        }
    }
}
