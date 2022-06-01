using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObject : MonoBehaviour
{
    float moveSpeed = 10f;

    [SerializeField] private Vector3 dir;

    void Update()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
