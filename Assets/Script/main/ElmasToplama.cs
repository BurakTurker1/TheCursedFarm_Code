using UnityEngine;
using UnityEngine.UI;

public class ElmasToplama : MonoBehaviour
{
    public Text elmasSayisiText; // UI �zerinde elmas say�s�n� g�steren metin alan�
    private int elmasSayisi = 0; // Toplanan elmas say�s�

    private void Start()
    {
        // UI �zerindeki metin alan�n� bulun ve ba�lang��ta elmas say�s�n� g�ncelleyin
        elmasSayisiText = GameObject.Find("ElmasSayisiText").GetComponent<Text>();
        GuncelleElmasSayisi();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Para")) // "Para" tag'�na sahip nesne ile temas etti�inde
        {
            Destroy(other.gameObject); // Elmas� yok et (opsiyonel, sadece g�r�n�rl��� kald�rmak i�in)

            elmasSayisi++; // Elmas say�s�n� artt�r
            GuncelleElmasSayisi(); // UI �zerinde elmas say�s�n� g�ncelle
        }
    }

    private void GuncelleElmasSayisi()
    {
      elmasSayisiText.text =elmasSayisi.ToString(); // UI �zerinde elmas say�s�n� yazd�r
    }
}
