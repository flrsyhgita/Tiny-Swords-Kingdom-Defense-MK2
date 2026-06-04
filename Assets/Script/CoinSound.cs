using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Lubang kaset untuk masukin file suara koin
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek apakah yang menyentuh koin adalah si katak (Player)
        if (collision.CompareTag("Player"))
        {
            // Mainkan suara koin tepat di posisi koin saat ini
            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            }

            // Hancurkan koinnya dari layar
            Destroy(gameObject);
        }
    }
}