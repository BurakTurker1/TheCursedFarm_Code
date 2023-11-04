using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecisKontrol : MonoBehaviour
{
    // Bayrak noktas�n�n pozisyonu
    public Transform bayrakNoktasi;

    // Karakter
    public GameObject oyuncu;

    // Yeni sahne ad�
    public string hedefSahneAdi = "b�l�m2";

    private bool sahneGecisiniYap = false;
     
    private void Update()
    {
        // Karakter bayrak noktas�na ula�t���nda ve sahne ge�i�i yap�lmam��sa
        if (!sahneGecisiniYap && Vector3.Distance(oyuncu.transform.position, bayrakNoktasi.position) < 1.0f)
        {
            sahneGecisiniYap = true;
            SceneManager.LoadScene(hedefSahneAdi);
        }
    }
}
