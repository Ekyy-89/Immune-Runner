using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Diubah jadi public agar bisa dibaca script lain, 
    // [HideInInspector] biar gak muncul di panel Unity Inspector
    [HideInInspector] public float score;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            // Tips: Kamu bisa kalikan dengan 10f biar angka skornya naik cepat seperti Dino Chrome
            score += 10f * Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
    }
}