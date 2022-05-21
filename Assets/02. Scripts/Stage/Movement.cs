using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
