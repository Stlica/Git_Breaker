using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    // 固定する座標を指定
    public Vector3 fixedPosition;

    void Start()
    {
        // 初期位置を設定
        transform.position = fixedPosition;
    }

    void Update()
    {
        // 毎フレーム指定した座標に固定
        transform.position = fixedPosition;
    }
}
