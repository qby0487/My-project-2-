using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraFollow : MonoBehaviour
{
    public Transform target; // 跟隨目標
    public float smoothSpeed = 0.125f; // 平滑速度
    public Vector3 offset; // 位置偏移

    // 可選的邊界限制
    public float minX = -100f;
    public float maxX = 100f;


    void LateUpdate()
    {
        if (target == null) return;

        // 計算目標位置
        Vector3 desiredPosition = target.position + offset;

        // 限制 X 和 Y 座標在指定範圍內
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
      //desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // 保持 Z 軸不變（通常用於2D遊戲）
        desiredPosition.z = transform.position.z;

        // 平滑移動
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}