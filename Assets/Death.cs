using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Death : MonoBehaviour
{
    public bool DeathMessage = false;
    public LayerMask DeathLayer;
    
    public PhysicsMaterial2D material2;
    private Collider2D col;

    public event Action Resetevent;

    //public event Action<bool> Deathevent;
    public Transform parentTransform; 
    [SerializeField]private int clonelimited = 5;

    [SerializeField]private Vector3 respawnPoint;

    public GameObject RepalyText;

     

    private void Start()
   {

        RepalyText.SetActive(false);

        CheckpointManager.Instance.OnCheckpointUpdated += UpdateRespawnPoint;
    
   }

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
        {
            Executedeath();
            ResetAllComponentsExceptOne<Death>();

            RepalyText.SetActive(false);
        
            transform.SetPositionAndRotation(respawnPoint, Quaternion.identity);
            transform.localScale = new Vector3(0.4f,1f,1f);  
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            Resetevent?.Invoke();
 
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    
            
             DeathMessage = false;
             clonelimited = 5;
          //   GetComponent<Checkpoint>().enabled = true;
        }
    }

void Executedeath()
{
    // 使用 for 循環從後往前刪除
    for (int i = transform.parent.childCount - 1; i >= 0; i--)
    {
        Transform child = transform.parent.GetChild(i);
        if (child.name == "player-clone")
        {
            Destroy(child.gameObject);
        }
    }    
}

void ResetAllComponentsExceptOne<T>() where T : Component
{
    // 獲取所有 Component
    Component[] components = GetComponents<Component>();
    
    foreach (Component component in components)
    {
        // 跳過 Transform 和指定的 Component 類型
        if (component is Transform || component is T)
            continue;
        
        // 如果是 Behaviour 類型（如 Script），可以直接禁用和啟用
        if (component is Behaviour behaviour)
        {
            behaviour.enabled = false;
            behaviour.enabled = true;
        }
        // 對於其他類型，可以嘗試重置
        else
        {
            // 這裡可能需要根據不同 Component 類型客製化重置邏輯
            component.GetType().GetMethod("Reset")?.Invoke(component, null);
        }
    }
}



   private void UpdateRespawnPoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
        Debug.Log($"重生點已更新至: {respawnPoint}");
    }

    void OnCollisionEnter2D(Collision2D other)
{
        Rigidbody2D rb = GetComponent<Rigidbody2D>();  
        Movement script = GetComponent<Movement>();
    if ((DeathLayer.value & (1 << other.gameObject.layer)) != 0)
    {
        DeathMessage = true;
          
       
        rb.constraints = RigidbodyConstraints2D.None; 
       
          
        script.enabled = false;
       //col.sharedMaterial = material2;
    }
   // if(other.gameObject.tag != "Player"){
      if (DeathMessage==true){
          
          
           // Resetevent?.Invoke(true);
          
          
            //  GetComponent<Checkpoint>().enabled = false;
            RepalyText.SetActive(true);
         Collider2D collider = other.collider;
         collider.sharedMaterial = material2;
         
         if (clonelimited > 0){
            transform.localScale = new Vector3(0.2f,0.25f,0f);
            clonelimited--;
            
            GameObject clone = Instantiate(gameObject, transform.parent);
            
            SpriteRenderer spriteRenderer = clone.GetComponent<SpriteRenderer>();
            //spriteRenderer.color = Color.red;
            clone.name = "player-clone";

            
        }

           // transform.localScale = transform.localScale * 0.999f;
            Vector3 randomForce = UnityEngine.Random.insideUnitSphere * 500f;
            rb.AddForce(randomForce);
        } 
   // }

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