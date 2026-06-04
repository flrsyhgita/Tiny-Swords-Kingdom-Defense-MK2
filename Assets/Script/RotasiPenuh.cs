using UnityEngine;

public class RotasiPenuh : MonoBehaviour
{
    [Header("Pengaturan Putaran 360°")]
    // Semakin besar angka, putarannya semakin cepat
    // Nilai positif = putar kiri, Nilai negatif = putar kanan
    public float kecepatanPutar = 100f;

    void Update()
    {
        // Memutar poros (anchor) terus-menerus pada sumbu Z
        transform.Rotate(Vector3.forward * kecepatanPutar * Time.deltaTime);
    }
}