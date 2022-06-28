using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashSin : MonoBehaviour
{
    Vector2 dir;
    [SerializeField] float speed = 3;
    //float currentTime;
    public float shakeSpeed;
    public float size;
    Vector2 Now;
    void Start()
    {
        dir = Vector3.zero;
        Now = transform.position;
    }

    void Update()
    {
        //currentTime += Time.deltaTime;
        //진폭 크기(float) * Mathf.Sin(Time.time * 윙아래 진동 속도(float));
        dir.y = size * Mathf.Sin(Time.time * shakeSpeed);// + Mathf.Tan(currentTime *3);
        transform.position = Now + dir;
        Now += new Vector2(-1, 0) * speed * Time.deltaTime;
    }
}
