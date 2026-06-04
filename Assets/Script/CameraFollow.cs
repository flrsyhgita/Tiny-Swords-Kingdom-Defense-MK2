using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target yang Diikuti")]
    public Transform target; // Tempat menaruh objek player

    [Header("Pengaturan Kamera")]
    public float smoothSpeed = 0.125f; // Kecepatan gerak kamera (semakin kecil, semakin smooth/lembut)
    public Vector3 offset = new Vector3(2f, 1f, -10f); // Jarak aman kamera dari player (Z harus -10)

    void LateUpdate()
    {
        if (target != null)
        {
            // Menghitung posisi ideal kamera berdasarkan posisi player + jarak offset
            Vector3 desiredPosition = target.position + offset;

            // Membuat pergerakan kamera transisi mulus menggunakan Lerp
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Mengubah posisi kamera ke posisi baru
            transform.position = smoothedPosition;
        }
    }
}