using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private StageData _stageData;

    private void Update()
    {
        if(_stageData.LimitMin.x - 2 > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
