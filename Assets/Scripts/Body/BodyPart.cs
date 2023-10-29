using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    static int bodyStaticID = 0;
    [HideInInspector] public int bodyPartID;
    [HideInInspector] public Rigidbody bodyPartRigidbody;
    internal bool IsMainBodyPart;

    private void Awake()
    {
        bodyPartID = bodyStaticID++;
        bodyPartRigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
}