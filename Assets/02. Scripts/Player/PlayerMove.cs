using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    [SerializeField] private StageData stageData;
    [SerializeField] private BoxCollider2D playerCollider;

    Rigidbody2D rb;
    private Vector3 _boundMax;
    private Vector3 _boundMin;
    private float _halfWidth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Calc()
    {
        _boundMax = playerCollider.bounds.max;
        _boundMin = playerCollider.bounds.min;

        _halfWidth = playerCollider.size.x / 2;
    }

    private void Update()
    {
        float x = Mathf.Clamp(Input.GetAxis("Horizontal"), stageData.LimitMin.x, stageData.LimitMax.x);
        float y = Mathf.Clamp(Input.GetAxis("Vertical"), stageData.LimitMin.y, stageData.LimitMax.y);

        Vector2 getMove = new Vector2(x, y) * speed;
        rb.velocity = getMove; ;
    }
}
