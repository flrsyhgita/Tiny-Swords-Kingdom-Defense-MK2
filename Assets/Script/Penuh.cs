using UnityEngine;

public class PendulumTrap : MonoBehaviour
{
    [Header("Pengaturan Ayunan")]
    public float batasSudut = 45f;
    public float kecepatanAyun = 2f;

    void Start()
    {
        // Reset rotasi saat game mulai
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        float sudut = batasSudut * Mathf.Sin(Time.time * kecepatanAyun);
        transform.rotation = Quaternion.Euler(0, 0, sudut);
    }
}