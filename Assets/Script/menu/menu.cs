using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    // Ana men� sahnesinin ad�n� buraya girin
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // "esc" tu�una bas�ld���nda ana men� sahnesine ge�i� yap
            SceneManager.LoadScene(0);
        }
    }
}
