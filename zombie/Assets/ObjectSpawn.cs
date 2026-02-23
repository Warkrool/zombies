using UnityEngine;
using System.Collections;

public class ObjectSpawn : MonoBehaviour
{
    public float minDistanceBetweenSpawns = 2f;

    public Transform platform;
    public GameObject prefab;
    public int numberofObject = 10;
    public float areaSize = 5f;

    public float areaX = 10f;
    public float areaZ = 10f;
    public float heightOffset = 2f;

    public float minAppearDelay = 1f;
    public float maxAppearDelay = 3f;

    public float minVisibleTime = 1f;
    public float maxVisibleTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(
                Random.Range(minAppearDelay, maxAppearDelay)
                );
            for (int i = 0; i < 5; i++)
            {
                Vector3 spawnPosition =
                    transform.position +
                    transform.right * Random.Range(-areaX, areaX) +
                    transform.forward * Random.Range(-areaZ, areaZ) +
                    transform.up * heightOffset;

                if(!Physics.CheckSphere(spawnPosition, minDistanceBetweenSpawns))
                {
                    GameObject obj = Instantiate(prefab, spawnPosition, Quaternion.identity);

                    float visibleTime = Random.Range(minVisibleTime, maxVisibleTime);
                    Destroy(obj, visibleTime);

                    break;
                }
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
