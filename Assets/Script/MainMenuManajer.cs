using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject characterPanel;
    public GameObject settingPanel;

    [Header("Karakter 2 (Unlock setelah Lvl 3)")]
    public Button char2Button;
    public GameObject gembokChar2;

    [Header("Karakter 3 (Unlock setelah Lvl 6 / opsional)")]
    public Button char3Button;
    public GameObject gembokChar3;

    void Start()
    {
        // Cek status gembok karakter setiap kali masuk Home Screen
        CekStatusKarakter();
    }

    // --- FUNGSI BUKA TUTUP PANEL ---
    public void BukaKarakter() => characterPanel.SetActive(true);
    public void TutupKarakter() => characterPanel.SetActive(false);
    public void BukaSetting() => settingPanel.SetActive(true);
    public void TutupSetting() => settingPanel.SetActive(false);

    // --- LOGIKA PROGRESSION GEMBOK ---
    void CekStatusKarakter()
    {
        // PlayerPrefs digunakan untuk menyimpan data permanen di HP/Laptop pemain
        // Kita ambil data level berapa yang sudah diselesaikan (default: 0)
        int levelSelesai = PlayerPrefs.GetInt("LevelTerakhirSelesai", 0);

        // SYARAT KARAKTER 2: Terbuka jika sudah menyelesaikan minimal Level 3
        if (levelSelesai >= 3)
        {
            char2Button.interactable = true; // Tombol bisa dipencet
            gembokChar2.SetActive(false);     // Gambar gembok hilang
        }
        else
        {
            char2Button.interactable = false; // Tombol mati
            gembokChar2.SetActive(true);      // Gambar gembok muncul
        }

        // SYARAT KARAKTER 3: (Contoh jika sudah menyelesaikan Level 6)
        if (levelSelesai >= 6)
        {
            char3Button.interactable = true;
            gembokChar3.SetActive(false);
        }
        else
        {
            char3Button.interactable = false;
            gembokChar3.SetActive(true);
        }
    }

    // --- FUNGSI LINK GOOGLE ---
    public void BukaLinkGoogle()
    {
        Application.OpenURL("https://www.google.com");
    }
}