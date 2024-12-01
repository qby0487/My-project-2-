using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraFollow : MonoBehaviour
{
    public Transform target; // ���H�ؼ�
    public float smoothSpeed = 0.125f; // ���Ƴt��
    public Vector3 offset; // ��m����

    // �i�諸��ɭ���
    public float minX = -100f;
    public float maxX = 100f;


    void LateUpdate()
    {
        if (target == null) return;

        // �p��ؼЦ�m
        Vector3 desiredPosition = target.position + offset;

        // ���� X �M Y �y�Цb���w�d��
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
      //desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // �O�� Z �b���ܡ]�q�`�Ω�2D�C���^
        desiredPosition.z = transform.position.z;

        // ���Ʋ���
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}