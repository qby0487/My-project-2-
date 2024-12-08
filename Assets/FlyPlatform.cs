using UnityEngine;
using System.Collections;

public class JumpPlatform2D : MonoBehaviour
{
    [Header("Platform Settings")]
    public float pauseDuration = 0.5f; // �Ȱ��ɶ�
    public float launchForce = 10f;    // �u�g�O
    public bool debugMode = true;      // �����Ҧ�

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DebugLog("���a��Ĳ���x");
            StartCoroutine(LaunchPlayerCoroutine(collision.gameObject));
        }
    }

    private System.Collections.IEnumerator LaunchPlayerCoroutine(GameObject player)
    {
        // �����Ĳ�o
        this.enabled = false;

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb == null)
        {
            DebugLog("���a�S��2D����ե�I");
            this.enabled = true;
            yield break;
        }

        // �Ȱ����a����
        DebugLog("�}�l�Ȱ����a");
        playerRb.velocity = Vector2.zero;

        // ���ݫ��w�ɶ�
        yield return new WaitForSeconds(pauseDuration);

        // �u�g���a
        DebugLog("�u�g���a");
        playerRb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

        // �u�ȩ���᭫�s�ҥ�
        yield return new WaitForSeconds(0.5f);
        this.enabled = true;
    }

    private void DebugLog(string message)
    {
        if (debugMode)
            Debug.Log($"[JumpPlatform2D] {message}");
    }
}