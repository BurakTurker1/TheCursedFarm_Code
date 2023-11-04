using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public float hareketHizi = 5.0f; // Karakterin hareket h�z�
    public float ziplamaGucu = 5.0f; // Z�plama g�c�
    private Rigidbody2D rb; // Rigidbody bile�eni
    private Animator animator; // Animator bile�eni
    private bool ziplamaYapabilir = true; // Z�plamaya izin verme kontrol�
    private bool sagaBakiyor = true; // Karakterin ba�ta sa�a m� sola m� bakt���n� kontrol eder

    public AudioSource kosmaSesi; // Ko�arken �alacak ses efekti
    public AudioSource ziplamaSesi; // Z�plarken �alacak ses efekti

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
        animator = GetComponent<Animator>(); // Animator bile�enini al
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Horizontal input (A/D veya sol/sa� ok tu�lar�)

        Vector2 movement = new Vector2(horizontalInput, 0); // Hareket vekt�r� olu�tur

        // Hareketi karakterin Rigidbody'sine uygula
        rb.velocity = new Vector2(movement.x * hareketHizi, rb.velocity.y);

        // Animator Controller'a hareket durumunu iletiyoruz
        animator.SetBool("isRun", Mathf.Abs(horizontalInput) > 0);

        if (ziplamaYapabilir && Input.GetButtonDown("Jump")) // "Jump" tu�una bas�ld���nda z�plamay� tetikle
        {
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse); // Z�plama g�c�n� uygula
            ziplamaYapabilir = false; // Birden fazla z�plamay� engelle
            animator.SetBool("isJump", true); // Z�plama animasyonunu ba�lat

            // Z�plama ses efektini �al
            ziplamaSesi.Play();
        }

        if (horizontalInput != 0)
        {
            // Ko�ma ses efektini �al
            kosmaSesi.Play();
        }

        if (horizontalInput > 0) // Sa�a do�ru hareket ediliyorsa
        {
            if (!sagaBakiyor) // Karakter sola bak�yorsa
            {
                transform.localScale = new Vector3(5, 5, 5); // Karakteri sa�a d�nd�r
                sagaBakiyor = true; // SagaBakiyor de�erini g�ncelle
            }
        }
        else if (horizontalInput < 0) // Sola do�ru hareket ediliyorsa
        {
            if (sagaBakiyor) // Karakter sa�a bak�yorsa
            {
                transform.localScale = new Vector3(-5, 5, 5); // Karakteri sola d�nd�r ve ters �evir
                sagaBakiyor = false; // SagaBakiyor de�erini g�ncelle
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin")) // Zeminle temas sa�land���nda
        {
            ziplamaYapabilir = true; // Tekrar z�plamaya izin ver
            animator.SetBool("isJump", false); // Z�plama animasyonunu kapat
        }
    }
}
