using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float speed = 2f; // Kecepatan jalan kepiting
    public float moveDistance = 2f; // Seberapa jauh dia jalan ke kiri/kanan sebelum putar balik

    private float startX;
    private bool movingRight = true;

    void Start()
    {
        // Ingat posisi awal si kepiting
        startX = transform.position.x;
    }

    void Update()
    {
        // Logika mondar-mandir
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // Kalau sudah terlalu jauh ke kanan, putar balik
            if (transform.position.x >= startX + moveDistance)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // Kalau sudah terlalu jauh ke kiri, putar balik
            if (transform.position.x <= startX - moveDistance)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    // Fungsi untuk membalikkan gambar kepiting (hadap kiri/kanan)
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}