using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{
    public bool DeathMessage = false;
    public LayerMask DeathLayer;
    
    public PhysicsMaterial2D material2;
    private Collider2D col;
   

    [SerializeField]private Vector3 respawnPoint;
  private void Start()
   {
    CheckpointManager.Instance.OnCheckpointUpdated += UpdateRespawnPoint;
   }


   private void UpdateRespawnPoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
        Debug.Log($"重生點已更新至: {respawnPoint}");
    }

    void OnCollisionEnter2D(Collision2D other)
{
    if ((DeathLayer.value & (1 << other.gameObject.layer)) != 0)
    {
        DeathMessage = true;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();    
       
        rb.constraints = RigidbodyConstraints2D.None; 
       
        Movement script = GetComponent<Movement>();
       
        script.enabled = false;
       //col.sharedMaterial = material2;
    }

      if (DeathMessage==true){
            
         Collider2D collider = other.collider;
         collider.sharedMaterial = material2;
        } 


}

}




















//public class GameManager : MonoBehaviour
//{
//    // 遊戲結束協程
//    IEnumerator EndGameCoroutine()
//    {
//        // 1. 停止所有正在運行的協程
//        StopAllCoroutines();

//        // 2. 暫停玩家輸入
//        playerControll.enabled = false;

//        // 3. 顯示遊戲結束畫面
//        gameOverPanel.SetActive(true);

//        // 4. 播放結束動畫或音效
//        gameOverAnimator.Play("GameOverAnimation");
//        audioSource.PlayOneShot(gameOverSound);

//        // 5. 等待一段時間後觸發其他邏輯
//        yield return new WaitForSeconds(2f);

//        // 6. 可以選擇返回主菜單
//        SceneManager.LoadScene("MainMenu");
//    }

//    // 觸發遊戲結束的方法
//    void GameOver()
//    {
//        StartCoroutine(EndGameCoroutine());
//    }
//}