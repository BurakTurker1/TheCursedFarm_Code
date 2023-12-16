using UnityEngine;
using UnityEngine.UI;

public class ElmasToplama : MonoBehaviour
{
    public Text elmasSayisiText; // UI üzerinde elmas sayýsýný gösteren metin alaný
    private int elmasSayisi = 0; // Toplanan elmas sayýsý

    private void Start()
    {
        // UI üzerindeki metin alanýný bulun ve baþlangýçta elmas sayýsýný güncelleyin
        elmasSayisiText = GameObject.Find("ElmasSayisiText").GetComponent<Text>();
        GuncelleElmasSayisi();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Para")) // "Para" tag'ýna sahip nesne ile temas ettiðinde
        {
            Destroy(other.gameObject); // Elmasý yok et (opsiyonel, sadece görünürlüðü kaldýrmak için)

            elmasSayisi++; // Elmas sayýsýný arttýr
            GuncelleElmasSayisi(); // UI üzerinde elmas sayýsýný güncelle
        }
    }

    private void GuncelleElmasSayisi()
    {
      elmasSayisiText.text =elmasSayisi.ToString(); // UI üzerinde elmas sayýsýný yazdýr
    }
}
