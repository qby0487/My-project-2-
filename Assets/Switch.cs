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

    public bool isAppear = true;
    void ToggleVisibility()
    {
        isAppear = !isAppear;
        if (isAppear==false){
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;}
        else{
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;}
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ToggleVisibility();
            Debug.Log("Testmessage");
        }
    }

}