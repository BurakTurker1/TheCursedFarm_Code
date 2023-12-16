using UnityEngine;
using UnityEngine.SceneManagement;


[DisallowMultipleComponent]
public class CanSistemi : MonoBehaviour
{
    public int canHakki = 3; // Baþlangýçta 3 can hakký

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
        // Oyuncuyu baþlangýç pozisyonuna yerleþtirme veya baþka bir iþlem
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
}
