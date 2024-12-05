using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichIdentity2 : MonoBehaviour
{
    [SerializeField] private bool isAppear = true;

    public bool IsAppear
    {
        get { return isAppear; }
        set
        {
            isAppear = value;
            UpdateVisibility();
        }
    }

    
    void UpdateVisibility()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        CircleCollider2D boxCollider = this.gameObject.GetComponent<CircleCollider2D>();

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
            //      Debug.Log("Testmessage");
        }
    }

    void Start()
    {
        UpdateVisibility();
    }

}
