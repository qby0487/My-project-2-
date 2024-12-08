using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class JumpPlatform : MonoBehaviour
//{
//    [Header("Platform Settings")]
//    //public float pauseDuration = 1.5f; // 暫停的時間（秒）
//    public float launchForce = 10f; // 彈射的力度
//    public bool isActive = true; // 平台是否啟用

//    private void OnCollisionEnter(Collision collision)
//    {
//        // 檢查是否為玩家
//        if (isActive && collision.gameObject.CompareTag("Player"))
//        {
//            // 獲取玩家的剛體組件
//            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

//            if (playerRigidbody != null)
//            {
//                // 啟動協程來處理暫停和彈射
//                StartCoroutine(LaunchPlayer(playerRigidbody));
//            }
//        }
//    }

//    private System.Collections.IEnumerator LaunchPlayer(Rigidbody playerRigidbody)
//    {
//        // 暫停玩家移動
//        playerRigidbody.isKinematic = true;

//        // 等待指定的暫停時間
//        yield return new WaitForSeconds(pauseDuration);

//        // 重新啟用物理效果
//        playerRigidbody.isKinematic = false;

//        // 向上施加彈射力
//        playerRigidbody.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
//    }

//    // 可以用於動態控制平台的啟用/禁用
//    public void SetPlatformActive(bool active)
//    {
//        isActive = active;
//    }
//}
