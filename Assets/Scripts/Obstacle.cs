using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private ScoreManager scoreManager;

    [Header("Pengaturan Kecepatan")]
    public float kecepatanAwal = 5f; // Kecepatan virus pas game baru mulai
    public float batasKecepatanMaksimal = 25f; // Batas biar game-nya gak mustahil dimainkan

    private float kecepatanSekarang;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Mencari ScoreManager yang ada di dalam game otomatis
        scoreManager = GameObject.FindWithTag("GameController").GetComponent<ScoreManager>();
        // NOTE: Pastikan objek Game Manager kamu di Unity sudah dikasih Tag "GameController" ya!
    }

    void Update()
    {
        // RUMUS DINO CHROME: Kecepatan bertambah seiring besarnya skor
        // Setiap naik 100 skor, kecepatan bertambah 1 angka
        if (scoreManager != null)
        {
            kecepatanSekarang = kecepatanAwal + (scoreManager.score / 100f);

            // Batasi kecepatannya biar gak over-speed
            kecepatanSekarang = Mathf.Clamp(kecepatanSekarang, kecepatanAwal, batasKecepatanMaksimal);
        }
        else
        {
            kecepatanSekarang = kecepatanAwal;
        }

        // Menggerakkan virus ke arah kiri layar
        transform.Translate(Vector3.left * kecepatanSekarang * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "borders")
        {
            Destroy(this.gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            Destroy(player.gameObject);
        }
    }
}