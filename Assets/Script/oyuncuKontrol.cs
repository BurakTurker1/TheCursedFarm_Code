using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public float hareketHizi = 5.0f; // Hareket h�z� ayar�
    public float ziplamaGucu = 8.0f; // Z�plama g�c� ayar�
    private Rigidbody2D rb;
    private Animator animator;
    private bool ziplamaYapabilir = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
        animator = GetComponent<Animator>(); // Animator bile�enini al
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

            // Z�plama durumunu Animator Controller'a iletiyoruz
            animator.SetBool("isJump", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Zemin ile temas sa�land���nda tekrar z�plamaya izin ver
        if (collision.gameObject.CompareTag("Zemin"))
        {
            ziplamaYapabilir = true;

            // Z�plama durumunu Animator Controller'a s�f�rl�yoruz
            animator.SetBool("isJump", false);
        }
    }
}
