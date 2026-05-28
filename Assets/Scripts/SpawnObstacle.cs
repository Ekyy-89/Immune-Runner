using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstacle;

    [Header("Rentang Posisi Spawn")]
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    [Header("Pengaturan Jeda Endless")]
    public float jedaAwalSpawn = 2.5f;
    public float batasJedaPalingCepat = 0.6f;

    private float timeBetweenSpawn;
    private float timeToSpawn;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
        timeBetweenSpawn = jedaAwalSpawn;
    }

    void Update()
    {
        if (scoreManager != null)
        {
            timeBetweenSpawn = jedaAwalSpawn - (scoreManager.score / 300f);
            timeBetweenSpawn = Mathf.Clamp(timeBetweenSpawn, batasJedaPalingCepat, jedaAwalSpawn);
        }

        if (Time.time > timeToSpawn)
        {
            spawn();
            timeToSpawn = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}