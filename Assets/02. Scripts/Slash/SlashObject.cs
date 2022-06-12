using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObject : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    [SerializeField] private Vector3 dir;

    void Update()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
