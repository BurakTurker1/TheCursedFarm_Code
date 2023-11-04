using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    // Ana menü sahnesinin adýný buraya girin
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // "esc" tuþuna basýldýðýnda ana menü sahnesine geçiþ yap
            SceneManager.LoadScene(0);
        }
    }
}
