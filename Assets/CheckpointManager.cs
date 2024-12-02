using UnityEngine;
using System;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; } // 單例模式
    public event Action<Vector3> OnCheckpointUpdated; // 事件：當前檢查點更新

    [SerializeField] private Vector3 currentCheckpoint; // 當前檢查點位置

    private void Awake()
    {
        // 確保只存在一個管理器實例
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
     //   Debug.Log($"新的存檔點已更新至: {currentCheckpoint}");
        OnCheckpointUpdated?.Invoke(currentCheckpoint); // 通知訂閱者
    }

    public Vector3 GetCurrentCheckpoint()
    {
        return currentCheckpoint; // 提供當前存檔點
    }
}