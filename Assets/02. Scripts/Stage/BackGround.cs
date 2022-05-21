using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] Transform target;


    void Update()
    {
        if (transform.position.x <= -speed)
        {
            transform.position = target.position + Vector3.right * speed;
        }
    }
}
