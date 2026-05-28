using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private AudioSource bgm; // Ubah jadi private karena kita akan cari otomatis

    void Start()
    {
        // Mencari objek musik secara otomatis saat scene baru dimulai/restart
        // Kita cari objek yang punya script BackgroundMusic
        BackgroundMusic musicScript = GameObject.FindObjectOfType<BackgroundMusic>();

        if (musicScript != null)
        {
            bgm = musicScript.GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            if (gameOverPanel != null && !gameOverPanel.activeSelf)
            {
                gameOverPanel.SetActive(true);

                // 1. Menghentikan semua pergerakan
                Time.timeScale = 0f;

                // 2. Menghentikan musik (sekarang variabel bgm sudah otomatis terisi)
                if (bgm != null)
                {
                    bgm.Stop();
                }
            }
        }
    }

    public void RestartGame()
    {
        // PENTING: Kembalikan waktu ke normal
        Time.timeScale = 1f;

        // Load ulang scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}