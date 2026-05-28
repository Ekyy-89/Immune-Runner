using UnityEngine;

public class Codeplayer : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 7f;
    public float jumpHeight = 8f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    private const float GROUND_CHECK_RADIUS = 0.2f;

    private float movement;
    private bool isGrounded;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Cek apakah menyentuh tanah
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position, GROUND_CHECK_RADIUS, groundLayer
            );
        }

        // Input pergerakan (A/D atau Panah)
        movement = Input.GetAxis("Horizontal");

        // Input Lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        Flip();
    }

    void FixedUpdate()
    {
        // Mengatur kecepatan jalan
        rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpHeight);
    }

    void Flip()
    {
        // Balik arah karakter (Kanan/Kiri)
        if (Mathf.Abs(movement) < 0.1f) return;

        Vector3 scale = transform.localScale;
        if (movement > 0f)
            scale.x = Mathf.Abs(scale.x);
        else if (movement < 0f)
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    void OnDrawGizmosSelected()
    {
        // Untuk melihat area deteksi tanah di Scene View (warna merah)
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, GROUND_CHECK_RADIUS);
    }
}