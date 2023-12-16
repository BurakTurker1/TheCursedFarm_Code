using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyuncuKontrol : MonoBehaviour
{
    public float hareketHizi = 5.0f; // Karakterin hareket hýzý
    public float ziplamaGucu = 5.0f; // Zýplama gücü
    private Rigidbody2D rb; // Rigidbody bileþeni
    private Animator animator; // Animator bileþeni
    private bool ziplamaYapabilir = true; // Zýplamaya izin verme kontrolü
    private bool sagaBakiyor = true; // Karakterin baþta saða mý sola mý baktýðýný kontrol eder
    private bool hareketEdiyor = false; // Karakterin hareket etme durumu
    private CanSistemi canSistemi; //can sistemi ile baðlantý

    public AudioSource kosmaSesi; // Koþarken çalacak ses efekti
    public AudioSource ziplamaSesi; // Zýplarken çalacak ses efekti

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
        animator = GetComponent<Animator>(); // Animator bileþenini al

        // Ses kaynaklarýna ses dosyalarýný atayýn
        kosmaSesi.clip = Resources.Load<AudioClip>("runSound"); // Koþma sesi için
        ziplamaSesi.clip = Resources.Load<AudioClip>("jumpSound"); // Zýplama sesi için
        canSistemi = GetComponent<CanSistemi>(); // Oyuncu nesnesi üzerinde CanSistemi bileþenini arar
        //can sistemi
        if (canSistemi == null)
        {
            Debug.LogError("CanSistemi bileþeni bulunamadý! Oyuncu nesnesine CanSistemi bileþenini eklediðinizden emin olun.");
        }

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Horizontal input (A/D veya sol/sað ok tuþlarý)

        Vector2 movement = new Vector2(horizontalInput, 0); // Hareket vektörü oluþtur

        // Hareketi karakterin Rigidbody'sine uygula
        rb.velocity = new Vector2(movement.x * hareketHizi, rb.velocity.y);

        // Animator Controller'a hareket durumunu iletiyoruz
        bool yeniHareketEdiyor = Mathf.Abs(horizontalInput) > 0;
        animator.SetBool("isRun", yeniHareketEdiyor);

        // Hareket durumu deðiþtiðinde koþma sesini çal
        if (yeniHareketEdiyor && !hareketEdiyor)
        {
            kosmaSesi.Play();
        }
        else if (!yeniHareketEdiyor)
        {
            kosmaSesi.Stop();
        }

        hareketEdiyor = yeniHareketEdiyor;

        if (ziplamaYapabilir && Input.GetButtonDown("Jump")) // "Jump" tuþuna basýldýðýnda zýplamayý tetikle
        {
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse); // Zýplama gücünü uygula
            ziplamaYapabilir = false; // Birden fazla zýplamayý engelle

            // Zýplama animasyonunu baþlat
            if (rb.velocity.y > 0)
            {
                animator.Play("jump");
            }
            else
            {
                animator.Play("jumptofall");
            }

            // Zýplama ses efektini çal
            ziplamaSesi.Play();
        }

        if (horizontalInput > 0) // Saða doðru hareket ediliyorsa
        {
            if (!sagaBakiyor) // Karakter sola bakýyorsa
            {
                transform.localScale = new Vector3(5, 5, 5); // Karakteri saða döndür
                sagaBakiyor = true; // SagaBakiyor deðerini güncelle
            }
        }
        else if (horizontalInput < 0) // Sola doðru hareket ediliyorsa
        {
            if (sagaBakiyor) // Karakter saða bakýyorsa
            {
                transform.localScale = new Vector3(-5, 5, 5); // Karakteri sola döndür ve ters çevir
                sagaBakiyor = false; // SagaBakiyor deðerini güncelle
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)  
    {
      
        if (collision.gameObject.CompareTag("Zemin"))
        {

            ziplamaYapabilir = true; // Tekrar zýplamaya izin ver
            animator.SetBool("isJump", false); // Zýplama animasyonunu kapat
        }
        else if (collision.gameObject.CompareTag("Tuzak"))
        {
            if (canSistemi != null)
            {
                canSistemi.CanKaybi();
            }
            else
            {
                Debug.LogError("CanSistemi bileþeni bulunamadý!");
            }
        }
    }
}
