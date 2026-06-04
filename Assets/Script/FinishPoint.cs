using UnityEngine;
using UnityEngine.SceneManagement; // Wajib ada untuk sistem pindah layar

public class FinishPoint : MonoBehaviour
{
    // Kamu bisa mengganti nama ini di Unity Inspector sesuai dengan nama Scene "You Win" kamu
    public string namaSceneLobby = "HomeScreen";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek apakah yang menyentuh garis finish adalah katak (Player)
        if (collision.CompareTag("Player"))
        {
            // --- INI KODE BARU UNTUK MEMBUKA GEMBOKNYA ---
            // Menyimpan data bahwa pemain sudah tamat Level 3
            PlayerPrefs.SetInt("LevelTerakhirSelesai", 3);
            PlayerPrefs.Save(); // Amankan datanya secara permanen
            // ----------------------------------------------

            // Pindah ke layar You Win atau Lobby
            SceneManager.LoadScene(namaSceneLobby);
        }
    }
}