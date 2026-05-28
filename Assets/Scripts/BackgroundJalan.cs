using UnityEngine;
using UnityEngine.UI;

public class BackgroundJalan : MonoBehaviour
{
    public RawImage gambar;
    public float kecepatanX;

    void Update()
    {
        // Pake unscaledDeltaTime biar tetep jalan walau game lagi "pause"
        gambar.uvRect = new Rect(gambar.uvRect.x + kecepatanX * Time.unscaledDeltaTime, 0, 1, 1);
    }
}