using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour {

    public float runSpeed = 0.6f;
    public float jumpForce = 2.6f;

    public float Jumptime1;
    public float Jumptime2;
    public PhysicsMaterial2D material1;
    public PhysicsMaterial2D material2;
    private Collider2D col;

    private Rigidbody2D body; // Variable for the RigidBody2D component.
    private SpriteRenderer sr; // Variable for the SpriteRenderer component.
    public bool Jumpcheck = true;
    [SerializeField] private bool isGrounded; //check if character is on the ground.
    public GameObject groundCheckPoint; // The object through which the isGrounded check is performed.
    public float groundCheckRadius; // isGrounded check radius.
    public LayerMask groundLayer; // Layer wich the character can jump on.

    GameObject currentfloor;
    private bool jumpPressed = false;
    private bool APressed = false;
    private bool DPressed = false;
    private bool Jumpstatus = false;



    void Awake() {
    body = GetComponent<Rigidbody2D>(); // Setting the RigidBody2D component.
    sr = GetComponent<SpriteRenderer>(); // Setting the SpriteRenderer component. 

    col = GetComponent<Collider2D>();
    col.sharedMaterial = material1;  //初始化材質，使材質為非彈性材質
  }

  // Update() is called every frame.
  void Update() {
    //death = GameObject.Find("DeathBlock").GetComponent<Death>().DeathMessage; 
    //    if (death != null)
    //    {if (death = true) 
    //        {
    //            Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //            rb.constraints = RigidbodyConstraints2D.None; // 完全解除所有約束
    //        }
    //    }
    if (isGrounded == true){
    if (Jumpstatus==true){
      Jumptime1= Time.time;
      Jumpstatus = false;
    }
    if (Input.GetKeyDown(KeyCode.Space)){
    Jumptime1 = Time.time;
    }
    
    if (Input.GetKeyUp(KeyCode.Space)){
      jumpPressed = true;
    }
    }
    else {
      if (Input.GetKey(KeyCode.Space))Jumpstatus=true;  
      else Jumpstatus=false;
    }
  
    if (Input.GetKey(KeyCode.Space)) if ((Time.time - Jumptime1)>1.35f)Debug.Log("finished");//蓄力跳的完成偵測，之後可加音效
    if (Input.GetKey(KeyCode.A)) APressed = true; 
    if (Input.GetKey(KeyCode.D)) DPressed = true; 
  }
  void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "normal"){
            if (other.contacts[0].normal == new Vector2(1f, 0f))
            { //normal tag right side
                Jumpcheck = false;
            }
            else if (other.contacts[0].normal == new Vector2(-1f, 0f))
            { //normal tag left side
                Jumpcheck = false;
            }
}
}
  // Update using for physics calculations.
  void FixedUpdate() {
   
      isGrounded = Physics2D.OverlapCircle(groundCheckPoint.transform.position, groundCheckRadius, groundLayer); // Checking if character is on the ground.
      if (isGrounded==true){Jumpcheck=true;}


      // Left/Right movement.
     if (Jumpcheck == true){
   
        col.sharedMaterial = material1; //切換材質為非彈性材質
   
        if (APressed) {
          body.velocity = new Vector2(-runSpeed, body.velocity.y); //左移
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the left.
          APressed = false; // Returning initial value.
      }
        else if (DPressed) {
          body.velocity = new Vector2(runSpeed, body.velocity.y); // 右移
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the right.
          DPressed = false; // Returning initial value.
      }

        else body.velocity = new Vector2(0, body.velocity.y);
    
        if (jumpPressed && isGrounded) {
            Jumptime2=Time.time;

          if ((Jumptime2 - Jumptime1) < 0.5f){
            body.velocity = new Vector2(0, jumpForce); // Jump physics.
            jumpPressed = false;  } // Returning initial value. 
          else{
            body.velocity = new Vector2(0, jumpForce*1.35f); //蓄力大跳
            jumpPressed = false;
          }   
      }
      }
      if (isGrounded == false){
        col.sharedMaterial = material2; //切換為彈性材質
      }
}
}