using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamMove : MonoBehaviour
{
    private float speed = 5f;
    [SerializeField] private int index;

    Rigidbody2D rb;
    Animator anim;

    [SerializeField] Rigidbody2D _player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = Vector2.right * speed ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PlayerRunning(2.5f));
    }

    IEnumerator PlayerRunning(float sec)
    {
        while (true)
        {
            yield return new WaitForSeconds(sec);
            anim.SetBool("Running", true);

            _player.velocity = Vector2.right * speed;

            yield return new WaitForSeconds(sec);

            SceneManager.LoadScene(index);
        }
    }
}
