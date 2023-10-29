using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    BodyPart bodyPart;

    private void Awake()
    {
        bodyPart = GetComponent<BodyPart>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        BodyPart otherBody = collision.gameObject.GetComponent<BodyPart>();

        // check if contacted with other cube
        if (otherBody != null && bodyPart.bodyPartID > otherBody.bodyPartID)
        {
            // check if both cubes have same number
            if (bodyPart == otherBody)
            {
                Vector3 contactPoint = collision.contacts[0].point;

                // the explosion should affect surrounded cubes too:
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach (Collider coll in surroundedCubes)
                {
                    if (coll.attachedRigidbody != null)
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                }


                // Destroy the two cubes:
                BodySpawner.Instance.DestroyBody(bodyPart);
                BodySpawner.Instance.DestroyBody(otherBody);
            }
        }
    }
}
