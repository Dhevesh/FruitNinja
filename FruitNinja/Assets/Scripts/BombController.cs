using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        BladeController b = collider.GetComponent<BladeController>();
        if (b)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else
        {
            return;
        }
    }
}
