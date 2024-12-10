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

    private Collider2D[] childColliders;
    void Start()
    {
        childColliders = GetComponentsInChildren<Collider2D>();
        death.Resetevent += ResetAllPhysicalObjects;

    }

    // Update is called once per frame

    void ResetAllPhysicalObjects()
{
    for (int i = 0; i < childColliders.Length; i++)
            {
                childColliders[i].sharedMaterial = null;
            }
}
}
