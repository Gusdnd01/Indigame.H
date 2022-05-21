using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObject : MonoBehaviour
{
    float moveSpeed = 10f;


    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = Vector3.right;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
