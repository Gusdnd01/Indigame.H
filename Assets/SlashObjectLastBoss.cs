using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashObjectLastBoss : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4f;
    /*
     * �׷��ϱ� ������ ���ŵ�?
     * �ٵ� ������ �� ��ũ��Ʈ���� �浹�Ҷ� �׋� velocity�� �ٲ��ְ�
     * �ٸ� ��ũ��Ʈ������ �� ��update���� �٤������� �׷��ϱ� velocity�� �α����ּ� �����ذ����� �����ΰ���
     * �� �� �ΰ� ��ġ�� �̤����O���ä���������
     * ��ގĺ�ī��������
     * ������
    */
    private void Start()//���� ������ �� �Ѿ˿� �ΰ��� ��ũ��Ʈ�� �����ι�
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    void Update()//�׷��� 
    {
        //rb.velocity += Vector2.up * speed * Time.deltaTime;
    }
}
