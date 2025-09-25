using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerUI : MonoBehaviour
{
    public Button musicBtn;
    public Button sfxButton;

    public Sprite unmutedBtnSprite;
    public Sprite muteBtnSprite;


    public void CheckMusicBtnState()
    {
        bool musicMuted = AudioManager.instance.IsMusicMuted();
        musicBtn.image.sprite = musicMuted ? muteBtnSprite : unmutedBtnSprite;
    }

    public void CheckSFXBtnState()
    {
        bool SFXMuted = AudioManager.instance.IsSFXMuted();
        sfxButton.image.sprite = SFXMuted ? muteBtnSprite : unmutedBtnSprite;
    }
}
