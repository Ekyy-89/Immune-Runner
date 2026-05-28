using UnityEngine;
using UnityEngine.SceneManagement; // Wajib dimasukkan agar bisa pindah scene

public class TombolLevel : MonoBehaviour
{
    // Fungsi ini dipanggil saat tombol START diklik
    public void MulaiGame()
    {
        // Langsung meluncur ke scene bermain game utama
        SceneManager.LoadScene("Scenes/Game Menu");
    }

    // Fungsi ini dipanggil saat tombol QUIT diklik
    public void KembaliKeMenu()
    {
        // Kembali ke scene menu utama yang ada gambar maskernya
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}