using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObjectLastBoss : MonoBehaviour
{
    private float speed = 3f;

    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        
    }
}
