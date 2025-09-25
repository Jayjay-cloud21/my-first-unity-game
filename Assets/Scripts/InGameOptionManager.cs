using UnityEngine;
using UnityEngine.UI;

public class InGameOptionManager : MonoBehaviour
{
    public GameObject OptionPanel;
    private LogicSCript logicSCript;

    public Slider musicSlider;

    public Slider sfxSlider;

    public ButtonControllerUI musicButtonController;
    public ButtonControllerUI sfxButtonController;

    void Start()
    {
        logicSCript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicSCript>();
        musicSlider.value = AudioManager.instance.GetMusicVolume();
        sfxSlider.value = AudioManager.instance.GetSFXVolume();
    }


    void Update()
    {
        musicSlider.value = AudioManager.instance.GetMusicVolume();
        sfxSlider.value = AudioManager.instance.GetSFXVolume();

        musicButtonController.CheckMusicBtnState();
        sfxButtonController.CheckSFXBtnState();
        
    }

    public void TogglePause()
    {

        OptionPanel.SetActive(true);
        logicSCript.TogglePause();
    }

    public void ToggleResume()
    {

        OptionPanel.SetActive(false);
        logicSCript.ToggleResume();
    }

    public void ToggleMainMenu()
    {
        logicSCript.ToggleMainMenu();
    }

    public void MuteMusic()
    {
        AudioManager.instance.ToggleMusic();
         
    }

    public void MuteSFX()
    {
        AudioManager.instance.ToggleSFX();
        
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
        
    }

    public void SfxVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
        
    }



}
