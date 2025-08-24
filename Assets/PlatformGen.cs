using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGen : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject platformPrefab;     // Assign your platform prefab here
    public Transform player;              // Reference to player transform
    public float platformLength = 10f;     // Length of each platform
    public int initialPlatforms = 5;       // How many platforms to start with
    public float spawnDistance = 30f;      // How far ahead to spawn new platforms
    public int maxPlatformsOnScreen = 7;   // Max number of platforms to keep alive
    private Queue<GameObject> platforms = new Queue<GameObject>();
    private void Start()
    {
        if (platformPrefab.transform.GetChild(0).TryGetComponent<BoxCollider>(out BoxCollider collider))
        {


            platformLength = collider.size.z * platformPrefab.transform.GetChild(0).transform.localScale.z;
        }
        else
        {
            Debug.LogWarning("Platform prefab has no BoxCollider! Please add one.");
        }

        nextSpawnZ = 0f;

        // Spawn initial platforms
        for (int i = 0; i < initialPlatforms; i++)
        {
            SpawnPlatform();
        }
    }
    private void Update()
    {
        if (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnPlatform();
            RemoveOldPlatform();

        }
    }

    private void SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab, new Vector3(0f, 0f, nextSpawnZ), Quaternion.identity);
        platforms.Enqueue(platform);
        nextSpawnZ += platformLength;
    }
    private void RemoveOldPlatform()
    {
        if (platforms.Count > maxPlatformsOnScreen+1)
        {
            GameObject oldPlatform = platforms.Dequeue();
            Destroy(oldPlatform);
        }
    }
    private float nextSpawnZ;
    
}
