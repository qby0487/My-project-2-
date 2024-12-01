using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour

{
  [SerializeField]private Vector3 respawnPoint;
  private void Start()
   {
    CheckpointManager.Instance.OnCheckpointUpdated += UpdateRespawnPoint;
   }
   private void UpdateRespawnPoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
        Debug.Log($"重生點已更新至: {respawnPoint}");
    }
}
