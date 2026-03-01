using UnityEngine;

public class SharkSpawner : MonoBehaviour
{
    public GameObject sharkPrefab;  
    public float spawnInterval = 2f;
    public float spawnY = 6f;       
    public float moveSpeed = 2f; 
    private float timer = 0f;

    private float[] lanes = { -2.3f, 0f, 2.3f };

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnShark();
        }
    }

    void SpawnShark()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        Vector3 spawnPos = new Vector3(lanes[laneIndex], spawnY, 0f);

        GameObject shark = Instantiate(sharkPrefab, spawnPos, Quaternion.identity);

        shark.AddComponent<SharkMovement>().moveSpeed = moveSpeed;
    }
}
