using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecisKontrol : MonoBehaviour
{
    // Bayrak noktasýnýn pozisyonu
    public Transform bayrakNoktasi;

    // Karakter
    public GameObject oyuncu;

    // Yeni sahne adý
    public string hedefSahneAdi = "bölüm2";

    private bool sahneGecisiniYap = false;
     
    private void Update()
    {
        // Karakter bayrak noktasýna ulaþtýðýnda ve sahne geçiþi yapýlmamýþsa
        if (!sahneGecisiniYap && Vector3.Distance(oyuncu.transform.position, bayrakNoktasi.position) < 1.0f)
        {
            sahneGecisiniYap = true;
            SceneManager.LoadScene(hedefSahneAdi);
        }
    }
}
