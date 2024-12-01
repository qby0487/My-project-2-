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

//public class SwichIdentity : MonoBehaviour
//{

//    public bool isAppear = true;
//    void ToggleVisibility()
//    {
//        isAppear = !isAppear;      
//        this.gameObject.GetComponent<SpriteRenderer>().enabled = !this.gameObject.GetComponent<SpriteRenderer>().enabled;
//        this.gameObject.GetComponent<BoxCollider2D>().enabled = !this.gameObject.GetComponent<BoxCollider2D>().enabled;
//    }


//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.W))
//        {
//            ToggleVisibility();
//            Debug.Log("Testmessage");
//        }
//    }

//}
public class SwichIdentity : MonoBehaviour
{
    // �ϥ� [SerializeField] ���p���ܼƦb Unity Inspector ���i��
    [SerializeField] private bool isAppear = true;

    // �K�[���@�ݩʥH���\�~���}������ isAppear
    public bool IsAppear
    {
        get { return isAppear; }
        set
        {
            isAppear = value;
            UpdateVisibility();
        }
    }

    // �N�����޿责�����W����k��
    void UpdateVisibility()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = this.gameObject.GetComponent<BoxCollider2D>();

        if (spriteRenderer != null)
            spriteRenderer.enabled = isAppear;

        if (boxCollider != null)
            boxCollider.enabled = isAppear;
    }

    void ToggleVisibility()
    {
        IsAppear = !IsAppear;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            ToggleVisibility();
            Debug.Log("Testmessage");
        }
    }

    void Start()
    {
        UpdateVisibility();
    }

}