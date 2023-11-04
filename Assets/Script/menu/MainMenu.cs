using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioSource musicAudioSource;
    private float originalVolume = 1.0f;
    private bool isMusicMuted = false;

    public Image imageToToggle; // Ses durumuna göre görüntüyü deðiþtireceðiniz Image bileþeni
    public Sprite soundOnSprite; // Ses açýkken kullanýlacak sprite
    public Sprite soundOffSprite; // Ses kapalýyken kullanýlacak sprite

    private void Start()
    {
        // Menü müziði için kullanýlacak AudioSource bileþenini alýn
        musicAudioSource = GetComponent<AudioSource>();
        originalVolume = musicAudioSource.volume; // Orijinal ses seviyesini kaydedin
    }

    public void PlayGame()
    {
        // Oyun sahnesini yüklemek için SceneManager'ý kullan
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMusic()
    {
        // Müziði aç veya kapa
        if (isMusicMuted)
        {
            musicAudioSource.volume = originalVolume; // Müziði aç
            imageToToggle.sprite = soundOnSprite; // Ses açýkken kullanýlacak görüntü
        }
        else
        {
            musicAudioSource.volume = 0.0f; // Müziði kapat
            imageToToggle.sprite = soundOffSprite; // Ses kapalýyken kullanýlacak görüntü
        }
        isMusicMuted = !isMusicMuted; // Müziðin durumu deðiþtir
    }
}
