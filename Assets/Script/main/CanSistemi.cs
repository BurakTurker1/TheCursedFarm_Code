using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]
public class CanSistemi : MonoBehaviour
{
    public int canHakki = 3; // Ba�lang��ta 3 can hakk�

    public void CanKaybi()
    {
        canHakki--;

        if (canHakki > 0)
        {
            YenidenBaslat();
        }
        else
        {
            AnaMenuyeDon();
        }
    }

    private void YenidenBaslat()
    {
        // Oyuncuyu ba�lang�� pozisyonuna yerle�tirme veya ba�ka bir i�lem
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
}
