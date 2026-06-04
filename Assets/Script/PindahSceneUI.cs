using UnityEngine;
using UnityEngine.SceneManagement; // Wajib diisi untuk mengatur perpindahan scene

public class PindahSceneUI : MonoBehaviour
{
    // Fungsi ini yang akan dipanggil oleh tombol nanti
    public void KeHalamanUtama(string namaScene)
    {
        // Menyimpan data bahwa pemain sudah menyelesaikan Level 3
        // Angka 3 ini yang dibaca oleh MainMenuManager untuk membuka gembok Karakter 2
        PlayerPrefs.SetInt("LevelTerakhirSelesai", 3);
        PlayerPrefs.Save(); // Simpan data secara permanen di memori game

        // Pindah ke scene halaman utama/home screen
        SceneManager.LoadScene(namaScene);
    }
}