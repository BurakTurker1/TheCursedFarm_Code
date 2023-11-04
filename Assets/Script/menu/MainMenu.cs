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

    public Image imageToToggle; // Ses durumuna g�re g�r�nt�y� de�i�tirece�iniz Image bile�eni
    public Sprite soundOnSprite; // Ses a��kken kullan�lacak sprite
    public Sprite soundOffSprite; // Ses kapal�yken kullan�lacak sprite

    private void Start()
    {
        // Men� m�zi�i i�in kullan�lacak AudioSource bile�enini al�n
        musicAudioSource = GetComponent<AudioSource>();
        originalVolume = musicAudioSource.volume; // Orijinal ses seviyesini kaydedin
    }

    public void PlayGame()
    {
        // Oyun sahnesini y�klemek i�in SceneManager'� kullan
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMusic()
    {
        // M�zi�i a� veya kapa
        if (isMusicMuted)
        {
            musicAudioSource.volume = originalVolume; // M�zi�i a�
            imageToToggle.sprite = soundOnSprite; // Ses a��kken kullan�lacak g�r�nt�
        }
        else
        {
            musicAudioSource.volume = 0.0f; // M�zi�i kapat
            imageToToggle.sprite = soundOffSprite; // Ses kapal�yken kullan�lacak g�r�nt�
        }
        isMusicMuted = !isMusicMuted; // M�zi�in durumu de�i�tir
    }
}
