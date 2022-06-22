using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern : MonoBehaviour
{
    [SerializeField] private GameObject bulletA;
    [SerializeField] private GameObject bulletB;

    public int patternIndex;
    public int currentPatternIndex;
    public int[] maxPatternIndex;
    void Awake()
    {
        
    }

    void Think()
    {
        patternIndex = patternIndex == 3 ? 0 : patternIndex + 1;
        currentPatternIndex = 0;
        switch (patternIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    void BossPattern_1()
    {
        currentPatternIndex++;

        if (currentPatternIndex < maxPatternIndex[patternIndex])
            Invoke("BossPattern_1", 2);
        else
            Invoke("Think", 2);
    }

    [ContextMenu("Å×½ºÆ®")]
    public void BossPattern_2()
    {
        float grid = 180f / 36;
        float angle = 0f;
        Quaternion rot = Quaternion.Euler(0,0,0);
        for (int i = 0; i < 36; i++)
        {
            rot = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletB, transform.position, rot);
            print(rot.eulerAngles.z);
            angle += grid;
        }
        /*currentPatternIndex++;

        if (currentPatternIndex < maxPatternIndex[patternIndex])
            Invoke("BossPattern_2", 4);
        else
            Invoke("Think", 2);*/
    }

    void BossPattern_3()
    {
        currentPatternIndex++;

        if (currentPatternIndex < maxPatternIndex[patternIndex])
            Invoke("BossPattern_3", 0.1f);
        else
            Invoke("Think", 2);
    }

    void BossPattern_4()
    {
        currentPatternIndex++;

        if (currentPatternIndex < maxPatternIndex[patternIndex])
            Invoke("BossPattern_4", 0.8f);
        else
            Invoke("Think", 2);
    }

    void Update()
    {
        
    }
}
