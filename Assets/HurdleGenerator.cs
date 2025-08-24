using UnityEngine;

public class HurdleGenerator : MonoBehaviour
{


    public Transform player;          // The player
    public float spawnDistance = 30f; // How far ahead to spawn
    public float spacing = 15f;       // Distance between each hurdle
    public int[] hurdlePositions;
    public GameObject[] variations;

    private float nextZ;

    void Start()
    {
        nextZ = player.position.z + spawnDistance;
    }

    void Update()
    {
        if (player.position.z + spawnDistance > nextZ)
        {
            SpawnHurdle();
            nextZ += spacing;
        }
    }

    void SpawnHurdle()
    {

        float x = hurdlePositions[Random.Range(0, hurdlePositions.Length)]; // Random side-to-side position
        Vector3 pos = new Vector3(0, 1, nextZ);
        Instantiate(variations[Random.Range(0, variations.Length)], pos, Quaternion.identity);


    }


}

