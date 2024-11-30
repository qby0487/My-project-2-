using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class SwichIdentity : MonoBehaviour
//{
//    public bool isAppear = true;
//}
//SwichIdentity identity = gameObject.GetComponent<SwichIdentity>();
//void update()
//{
//    if (Input.GetKeyDown(KeyCode.W))
//    {
//        if (identity.isAppear)
//        {
//            this.gameObject.SetActive(false);
//            identity.isAppear = false;
//        }
//        else 
//        {
//            this.gameObject.SetActive(true);
//            identity.isAppear = true;
//        }

//    }
//}
public class SwichIdentity : MonoBehaviour
{
    // 公開布爾變數，預設為true（物件可見）
    public bool isAppear = true;

    void Update()
    {
        // 當按下W鍵時
        if (Input.GetKeyDown(KeyCode.W))
        {
            // 切換物件的顯示狀態
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        // 反轉當前狀態
        isAppear = !isAppear;
        // 設置物件的活躍狀態
        gameObject.SetActive(isAppear);
    }
}