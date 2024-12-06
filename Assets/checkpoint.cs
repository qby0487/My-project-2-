using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class Checkpoint : MonoBehaviour
{   
  


    [SerializeField] private bool Checkpointenable=true;

  



   private   void OnTriggerEnter2D(Collider2D other){
           if (Checkpointenable == true){
            if (other.CompareTag("Player")){
                Vector3 checkpointPosition = transform.position;
             CheckpointManager.Instance.UpdateCheckpoint(checkpointPosition);    
             Checkpointenable = false;}
        }
    }


}
