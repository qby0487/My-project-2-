using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class ResetScence : MonoBehaviour
{
    // Start is called before the first frame update

    public Death death;
    void Start()
    {
        death.Resetevent += ResetAllPhysicalObjects;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetAllPhysicalObjects()
{
    Collider2D[] colliders = FindObjectsOfType<Collider2D>();
    foreach (Collider2D col in colliders)
    {
        col.sharedMaterial = null;
       // Debug.Log("test");
    }






}
}
