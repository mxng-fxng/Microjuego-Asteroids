using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRatePerMinnute = 30f;
    public float spawnRateIncrement = 1f;
    public float xlimit = 0;
    public float maxTimeLife = 4f;
    private float spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext)
        {
            spawnNext = Time.time + 60 / spawnRatePerMinnute;
            spawnRatePerMinnute += spawnRateIncrement;
            float rand = Random.Range(-xlimit, xlimit);
            Vector2 spawnPosition = new Vector2(rand, 8f);
            GameObject meteor = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            Destroy(meteor, maxTimeLife);
        }
    }
}
