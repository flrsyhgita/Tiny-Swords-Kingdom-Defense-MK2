using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahLevel : MonoBehaviour
{
    // Kotak isian di Unity untuk menentukan tujuan level
    public string namaSceneTujuan;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Cek apakah yang menyentuh piala adalah si katak (Tag: Player)
        if (collision.CompareTag("Player"))
        {
            // 2. Piala menghitung jumlah sisa pisang di dalam map yang memakai Tag "Coin"
            GameObject[] sisaPisang = GameObject.FindGameObjectsWithTag("Coin");

            // 3. Jika sisa pisang sudah 0 (habis dimakan semua)
            if (sisaPisang.Length == 0)
            {
                Debug.Log("MANTAP! Semua pisang sudah diambil, meluncur ke " + namaSceneTujuan);
                SceneManager.LoadScene(namaSceneTujuan);
            }
            // 4. Jika pisang masih ada yang tersisa
            else
            {
                // Akan muncul pesan peringatan di tab Console Unity
                Debug.Log("Eits, tidak bisa lewat! Masih ada " + sisaPisang.Length + " pisang yang belum diambil!");
            }
        }
    }
}