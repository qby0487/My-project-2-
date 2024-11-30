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
    // ���}�����ܼơA�w�]��true�]����i���^
    public bool isAppear = true;

    void Update()
    {
        // ����UW���
        if (Input.GetKeyDown(KeyCode.W))
        {
            // ����������ܪ��A
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        // �����e���A
        isAppear = !isAppear;
        // �]�m���󪺬��D���A
        gameObject.SetActive(isAppear);
    }
}