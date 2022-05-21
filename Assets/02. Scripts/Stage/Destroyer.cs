using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private StageData _stageData;

    private void Update()
    {
        if(Mathf.Abs(_stageData.LimitMax.x) > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
