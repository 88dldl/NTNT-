using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPosition : MonoBehaviour
{
    private Transform targetTransform; // 폭발 위치를 지정할 타겟 Transform

    public void SetTargetTransform(Transform target)
    {
        targetTransform = target;
    }

    private void Start()
    {
        if (targetTransform != null)
        {
            transform.position = targetTransform.position;
        }
    }
}
