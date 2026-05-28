using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;

    void Awake()
    {
        // HAPUS transform.SetParent(null) karena bisa ngerusak struktur UI jika salah tempel

        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Jika musik yang asli sudah ada, mainkan yang asli lalu hancurkan duplikatnya
            AudioSource source = backgroundMusic.GetComponent<AudioSource>();
            if (source != null && !source.isPlaying)
            {
                source.Play();
            }

            Destroy(gameObject);
            return;
        }

        // Pastikan saat pertama kali muncul juga bunyi
        AudioSource startSource = GetComponent<AudioSource>();
        if (startSource != null && !startSource.isPlaying)
        {
            startSource.Play();
        }
    }
}