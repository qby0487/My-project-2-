using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{

    [SerializeField] private bool Slidecheck = false;

     public GameObject SlideCheckPoint; // The object through which the isGrounded check is performed.
    public float SlideCheckRadius; // isGrounded check radius.
    public LayerMask slideLayer; // Layer wich the character can jump on.

    private Rigidbody2D body;



    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Slidecheck==true){
            
        }
    }
     private void FixedUpdate()
    {
        Slidecheck = Physics2D.OverlapCircle(SlideCheckPoint.transform.position,SlideCheckRadius, slideLayer);
    }
}
