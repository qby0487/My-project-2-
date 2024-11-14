using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour {
  public float runSpeed = 0.6f; 
  public float jumpForce = 2.6f; 

  public PhysicsMaterial2D material1; 
  public PhysicsMaterial2D material2;
  private Collider2D col;

  private Rigidbody2D body; // Variable for the RigidBody2D component.
  private SpriteRenderer sr; // Variable for the SpriteRenderer component.
  public bool Jumpcheck = true;
  [SerializeField] private bool isGrounded; // Variable that will check if character is on the ground.
  public GameObject groundCheckPoint; // The object through which the isGrounded check is performed.
  public float groundCheckRadius; // isGrounded check radius.
  public LayerMask groundLayer; // Layer wich the character can jump on.

   GameObject currentfloor;
  private bool jumpPressed = false; 
  private bool APressed = false; 
  private bool DPressed = false; 

  private bool Hold = false;

  void Awake() {
    body = GetComponent<Rigidbody2D>(); // Setting the RigidBody2D component.
    sr = GetComponent<SpriteRenderer>(); // Setting the SpriteRenderer component. 

    col = GetComponent<Collider2D>();
    col.sharedMaterial = material1;
  }

  // Update() is called every frame.
  void Update() {
    if (Input.GetKey(KeyCode.W)) Hold = true;      //蓄力跳由這開始
    if (Input.GetKeyDown(KeyCode.W)) jumpPressed = true; 
    if (Input.GetKey(KeyCode.A)) APressed = true; 
    if (Input.GetKey(KeyCode.D)) DPressed = true; 
  }
  void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "normal"){
            if (other.contacts[0].normal == new Vector2(1f,0f) ){
              Jumpcheck = false;
            }
            else if (other.contacts[0].normal == new Vector2(-1f,0f) ){
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
   
        col.sharedMaterial = material1;
   
        if (APressed) {
          body.velocity = new Vector2(-runSpeed, body.velocity.y); // Move left physics.
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z); // Rotating the character object to the left.
          APressed = false; // Returning initial value.
      }
        else if (DPressed) {
          body.velocity = new Vector2(runSpeed, body.velocity.y); // Move right physics.
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z); // Rotating the character object to the right.
          DPressed = false; // Returning initial value.
      }
        else body.velocity = new Vector2(0, body.velocity.y);
      
      
        if (jumpPressed && isGrounded) {
            body.velocity = new Vector2(0, jumpForce); // Jump physics.
            jumpPressed = false; // Returning initial value.   
      }
      }
      if (isGrounded == false){
        col.sharedMaterial = material2;
      }
}
  }
