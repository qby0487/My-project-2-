using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System;
public class Checkpoint : MonoBehaviour
{   


   private   void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Player")){
                Vector3 checkpointPosition = transform.position;
             CheckpointManager.Instance.UpdateCheckpoint(checkpointPosition);
              
        }
    }


}
