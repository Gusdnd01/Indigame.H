using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    [SerializeField] private StageData stageData;
    [SerializeField] private BoxCollider2D playerCollider;

    private Vector3 _boundMax;
    private Vector3 _boundMin;
    private float _halfWidth;

    void Calc()
    {
        _boundMax = playerCollider.bounds.max;
        _boundMin = playerCollider.bounds.min;

        _halfWidth = playerCollider.size.x / 2;
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 pos = transform.position;
        float min = _boundMin.x + _halfWidth;
        float max = _boundMax.x - _halfWidth;
        pos.x = Mathf.Clamp(pos.x + speed * h * Time.deltaTime, min, max);

        transform.position = pos;
    }

    
}
