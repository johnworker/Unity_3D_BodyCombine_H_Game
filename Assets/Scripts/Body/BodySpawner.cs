using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    // Singleton class
    public static BodySpawner Instance;

    Queue<BodyPart> bodysQueue = new Queue<BodyPart>();
    [SerializeField] private int bodysQueueCapacity = 20;
    [SerializeField] private bool autoQueueGrow = true;

    [SerializeField] private GameObject[] bodyPrefab;


    private Vector3 defaultSpawnPosition;

    private void Awake()
    {
        Instance = this;

        defaultSpawnPosition = transform.position;

        InitializeCubesQueue();

    }

    private void InitializeCubesQueue()
    {
        for (int i = 0; i < bodysQueueCapacity; i++)
            AddBodyPartToQueue();
    }

    private void AddBodyPartToQueue()
    {
        int randomPrefabIndex = Random.Range(0, bodyPrefab.Length);
        BodyPart bodyPart = Instantiate(bodyPrefab[randomPrefabIndex], defaultSpawnPosition, Quaternion.identity, transform)
                            .GetComponent<BodyPart>();

        bodyPart.gameObject.SetActive(false);
        bodyPart.IsMainBodyPart = false;
        bodysQueue.Enqueue(bodyPart);
    }

    public void DestroyCube(BodyPart bodyPart)
    {
        bodyPart.bodyPartRigidbody.velocity = Vector3.zero;
        bodyPart.bodyPartRigidbody.angularVelocity = Vector3.zero;
        bodyPart.transform.rotation = Quaternion.identity;
        bodyPart.IsMainBodyPart = false;
        bodyPart.gameObject.SetActive(false);
        bodysQueue.Enqueue(bodyPart);
    }

    public int GenerateRandomNumber()
    {
        return (int)Mathf.Pow(2, Random.Range(1, 6));
    }
}
