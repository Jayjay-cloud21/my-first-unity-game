using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;
    public Button musicButton, sfxButton;

    public Sprite muteBtnSprite, unmuteBtnSprite;

    void Start()
    {
        musicSlider.value = AudioManager.instance.GetMusicVolume();
        SFXSlider.value = AudioManager.instance.GetSFXVolume();
    }

    void Update()
    {
        musicSlider.value = AudioManager.instance.GetMusicVolume();
        SFXSlider.value = AudioManager.instance.GetSFXVolume();

        bool musicMuted = AudioManager.instance.IsMusicMuted();
        musicButton.image.sprite = musicMuted || musicSlider.value == 0 ? muteBtnSprite : unmuteBtnSprite;


        bool sfxMuted = AudioManager.instance.IsSFXMuted();
        sfxButton.image.sprite = sfxMuted || SFXSlider.value == 0 ? muteBtnSprite : unmuteBtnSprite;
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }


    public void SfxVolume()
    {
        AudioManager.instance.SFXVolume(SFXSlider.value);
    }
}
