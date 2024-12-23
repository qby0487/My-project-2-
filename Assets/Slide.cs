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

    private float Rotation;

    private float OtherRotation;


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


     private void FixedUpdate()
    {
        Slidecheck = Physics2D.OverlapCircle(SlideCheckPoint.transform.position,SlideCheckRadius, slideLayer);
             
                if (Slidecheck==true){
             //body.isKinematic = true;
             transform.position = SlideCheckPoint.transform.position - new Vector3(0f, 0.5f, 0f);
            Rotation = transform.eulerAngles.y;
            sliding();
            }
          //  else body.isKinematic = false;
   
    }
    void sliding(){

    }
    private void OnTriggerEnter2D(Collider2D other) {
        
            OtherRotation = other.transform.rotation.eulerAngles.z;
            Debug.Log(OtherRotation);
    }


}
