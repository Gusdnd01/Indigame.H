using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    [SerializeField] private StageData stageData;

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector3(h, v, 0);

        transform.Translate(dir * speed * Time.deltaTime);

        transform.position = new Vector3
         (Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
        Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }
}
