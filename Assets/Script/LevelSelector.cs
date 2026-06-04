using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Fungsi untuk memanggil level berdasarkan nama Scene-nya
    public void BukaLevel(string namaScene)
    {
        // Membuka scene sesuai nama yang kita ketik nanti di Inspector
        SceneManager.LoadScene(namaScene);
    }
}