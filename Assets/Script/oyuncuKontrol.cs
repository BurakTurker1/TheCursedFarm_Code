using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public float hareketHizi = 5.0f; // Hareket hýzý ayarý
    public float ziplamaGucu = 8.0f; // Zýplama gücü ayarý
    private Rigidbody2D rb;
    private Animator animator;
    private bool ziplamaYapabilir = true;
    private bool sagaBakiyor = true; // Karakterin ilk baþta saða bakýp bakmadýðýný belirtir

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);

        // Hareketi karakterin Rigidbody'sine uygula
        rb.velocity = new Vector2(movement.x * hareketHizi, rb.velocity.y);

        // Hareket durumunu Animator Controller'a iletiyoruz
        animator.SetBool("isRun", Mathf.Abs(horizontalInput) > 0);

        if (ziplamaYapabilir && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse);
            ziplamaYapabilir = false;
            animator.SetBool("isJump", true);
        }

        // Karakterin dönme animasyonlarýný ayarlayýn
        if (horizontalInput > 0)
        {
            // Saða doðru hareket ediyor, saða dönme animasyonunu oynatýn
            if (!sagaBakiyor)
            {
                transform.localScale = new Vector3(5, 5, 5); // Karakteri saða döndür
                sagaBakiyor = true;
            }
        }
        else if (horizontalInput < 0)
        {
            // Sola doðru hareket ediyor, sola dönme animasyonunu oynatýn
            if (sagaBakiyor)
            {
                transform.localScale = new Vector3(-5, 5, 5); // Karakteri sola döndür ve ters çevir
                sagaBakiyor = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemin ile temas saðlandýðýnda tekrar zýplamaya izin ver
        if (collision.gameObject.CompareTag("Zemin"))
        {
            ziplamaYapabilir = true;
            animator.SetBool("isJump", false);
        }
    }
}
