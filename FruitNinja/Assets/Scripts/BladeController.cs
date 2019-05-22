using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour
{
    public float bladeVelocity = 0.1f;

    private Rigidbody2D rb;
    private Collider2D bladeCollider;
    private Vector3 lastBladePos;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bladeCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
        bladeCollider.enabled = isBladeMoving();
    }

    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool isBladeMoving()
    {
        Vector3 currentBladePos = transform.position;
        float bladeTravelled = (lastBladePos - currentBladePos).magnitude;
        lastBladePos = currentBladePos;
        if (bladeTravelled > bladeVelocity)
            return true;
        else
            return false;
    }
}
