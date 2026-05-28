using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ambil input horizontal (A/D atau Panah Kanan/Kiri)
        float directionX = Input.GetAxisRaw("Horizontal");

        // Ambil input vertical (W/S atau Panah Atas/Bawah)
        float directionY = Input.GetAxisRaw("Vertical");

        // Masukin dua-duanya ke playerDirection
        playerDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate()
    {
        // Sekarang velocity-nya pake X dan Y, bukan 0 lagi di bagian X
        rb.linearVelocity = new Vector2(playerDirection.x * playerspeed, playerDirection.y * playerspeed);
    }
}