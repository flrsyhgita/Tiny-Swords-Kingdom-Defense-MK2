using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;

    // Variabel ini akan muncul di Inspector biar kamu gampang atur tingginya!
    public float kekuatanPantulan = 15f;

    void Start()
    {
        // Menyambungkan kodingan ini dengan komponen Animator di trampolin
        anim = GetComponent<Animator>();
    }

    // Fungsi ini otomatis berjalan ketika ada objek yang menyentuh trampolin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengecek apakah objek yang menyentuh memiliki Tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Memicu animasi loncat trampolin
            anim.SetTrigger("JumpTrigger");

            // 2. Mengambil komponen Rigidbody2D dari pemain
            Rigidbody2D rbPemain = collision.gameObject.GetComponent<Rigidbody2D>();

            // 3. Kalau pemain punya Rigidbody2D, pantulkan dia ke atas!
            if (rbPemain != null)
            {
                // Kita biarkan kecepatan maju/mundur (X) tetap, tapi kecepatan atas/bawah (Y) kita dorong!
                rbPemain.linearVelocity = new Vector2(rbPemain.linearVelocity.x, kekuatanPantulan);
            }
        }
    }
}