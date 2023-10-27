using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    static int bodyID = 0;
    [HideInInspector] public int bodyPartID;
    [SerializeField] private GameObject[] bodyPart;
    [HideInInspector] public Rigidbody bodyPartRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
