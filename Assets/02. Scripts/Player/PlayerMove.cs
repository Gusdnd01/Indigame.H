using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    [SerializeField] private StageData stageData;
    Rigidbody2D rb;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v).normalized;

        rb.velocity = dir * speed;

        

        //float x = transform.position.x;
        //float y = transform.position.y;

        //x = Mathf.Clamp(x, stageData.LimitMin.x, stageData.LimitMax.x);
        //y = Mathf.Clamp(y, stageData.LimitMin.y, stageData.LimitMax.y);

        //transform.position = new Vector3(x,y,0);
    }

    public void AudioPlay()
    {
        audioSource.Play();
    }
}
