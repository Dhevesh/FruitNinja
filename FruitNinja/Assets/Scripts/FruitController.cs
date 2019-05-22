using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float minExplosionForce = 300;
    public int maxExplosionForce = 800;
    public int points;

    public void CreateSlicedFruit()
    {
        GameObject slicedFruitInstance = Instantiate(slicedFruitPrefab, transform.position, transform.rotation) as GameObject;
        print (slicedFruitInstance.name);
        Rigidbody[] rbs = slicedFruitInstance.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(minExplosionForce, maxExplosionForce), transform.position, 5f);
        }
        Destroy(gameObject);
        Destroy(slicedFruitInstance, 5f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        BladeController b = collider.GetComponent<BladeController>();
        if (b)
        {
            CreateSlicedFruit();
            FindObjectOfType<GameManager>().IncreaseScore(points);
        }
        else
        {
            return;
        }

    }
}
