using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObjectLastBoss : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4f;
    /*
     * 그러니까 문제가 없거든?
     * 근데 문제는 한 스크립트에서 충돌할때 그떄 velocity를 바꿔주고
     * 다른 스크립트에서는 거 ㅋupdate에서 바ㅋㅋ꿔줘 그러니까 velocity가 두군데애서 제어해가지고 문제인거임
     * 걍 이 두게 합치자 이ㅋㅋ긐다읔ㅁㅋㅋㅋㅋ
     * 기달렼보카ㅋㅋㅋㅋ
     * ㅋㅋㅋ
    */
    private void Start()//지금 문제가 한 총알에 두개의 스크립트가 있음싸발
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    void Update()//그러면 
    {
        //rb.velocity += Vector2.up * speed * Time.deltaTime;
    }
}
