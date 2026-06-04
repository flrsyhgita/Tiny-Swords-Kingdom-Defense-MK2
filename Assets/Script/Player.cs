using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Pengaturan Kecepatan")]
    public float speed = 5f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 12f;

    [Header("Pengaturan Lompat")]
    public int extraJumpsAllowed = 1;
    private int jumpCount = 0;

    [Header("Pengaturan UI")]
    [Tooltip("Teks awalan sebelum angka skor, contoh: 'Score : '")]
    public string teksAwalanSkor = "Score : ";
    public TextMeshProUGUI scoreText;

    [Header("Pengaturan Nyawa")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private static int score = 0;
    private static int lives = 3;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isGrounded;
    private Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        // SENSOR AMAN: Cek apakah komponen fisik katak lengkap
        if (rb == null) Debug.LogError("⚠️ SENSOR: Rigidbody2D tidak ditemukan di objek Player!");
        if (anim == null) Debug.LogError("⚠️ SENSOR: Animator tidak ditemukan di objek Player!");
        if (sprite == null) Debug.LogError("⚠️ SENSOR: SpriteRenderer tidak ditemukan di objek Player!");

        startPosition = transform.position;

        UpdateUI();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (rb != null) rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput != 0)
        {
            if (anim != null) anim.SetBool("isRunning", true);
            if (sprite != null) sprite.flipX = (moveInput < 0);
        }
        else
        {
            if (anim != null) anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jumpCount = 0;
                if (rb != null) rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (jumpCount < extraJumpsAllowed)
            {
                jumpCount++;
                if (rb != null) rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
                if (anim != null) anim.SetTrigger("doubleJump");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Berjalan jika duri/musuh TIDAK dicentang Is Trigger (Benda Padat)
        if (collision.gameObject.CompareTag("Ground")) isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy")) TakeDamage();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek tabrakan dengan koin
        if (collision.gameObject.CompareTag("Coin"))
        {
            score += 10;
            UpdateUI();
            Destroy(collision.gameObject);
        }

        // --- BERJALAN JIKA DURI/MUSUH DICENTANG IS TRIGGER ---
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            lives = 3;
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            if (rb != null && sprite != null)
            {
                rb.linearVelocity = Vector2.zero;
                float arahPentalan = sprite.flipX ? 1f : -1f;
                rb.AddForce(new Vector2(arahPentalan * 5f, 7f), ForceMode2D.Impulse);
            }
        }
    }

    void UpdateUI()
    {
        if (scoreText != null) scoreText.text = teksAwalanSkor + score;

        // SENSOR AMAN: Cek isi Array Hearts
        if (hearts == null || hearts.Length == 0)
        {
            Debug.LogWarning("⚠️ SENSOR: Kotak 'Hearts' di Inspector Player masih kosong / berukuran 0!");
            return;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == null) continue;
            if (fullHeart == null || emptyHeart == null) continue;

            hearts[i].sprite = (i < lives) ? fullHeart : emptyHeart;
        }
    }
}