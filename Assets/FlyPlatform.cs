using UnityEngine;
using System.Collections;

public class JumpPlatform2D : MonoBehaviour
{
    [Header("Platform Settings")]
    public float pauseDuration = 0.5f; // 暫停時間
    public float launchForce = 10f;    // 彈射力
    public bool debugMode = true;      // 除錯模式

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DebugLog("玩家接觸平台");
            StartCoroutine(LaunchPlayerCoroutine(collision.gameObject));
        }
    }

    private System.Collections.IEnumerator LaunchPlayerCoroutine(GameObject player)
    {
        // 防止重複觸發
        this.enabled = false;

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb == null)
        {
            DebugLog("玩家沒有2D剛體組件！");
            this.enabled = true;
            yield break;
        }

        // 暫停玩家移動
        DebugLog("開始暫停玩家");
        playerRb.velocity = Vector2.zero;

        // 等待指定時間
        yield return new WaitForSeconds(pauseDuration);

        // 彈射玩家
        DebugLog("彈射玩家");
        playerRb.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);

        // 短暫延遲後重新啟用
        yield return new WaitForSeconds(0.5f);
        this.enabled = true;
    }

    private void DebugLog(string message)
    {
        if (debugMode)
            Debug.Log($"[JumpPlatform2D] {message}");
    }
}