using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    [SerializeField] Image soundOnIcon2;
    [SerializeField] Image soundOffIcon2;

    [SerializeField] Image soundOnIcon3;
    [SerializeField] Image soundOffIcon3;

    private bool muted = false;

    /// <summary>
    /// Audio clip that will be played when snake collects an apple.
    /// </summary>
    public AudioClip AppleClip;

    /// <summary>
    /// Audio clip that will be played when snake collects a bonus.
    /// </summary>
    public AudioClip BonusClip;

    /// <summary>
    /// Audio clip that will be played when game is over.
    /// </summary>
    public AudioClip GameOverClip;

    /// <summary>
    /// Audio source for an apple sound clip.
    /// </summary>
    private AudioSource appleAudioSource;

    /// <summary>
    /// Audio source for a bonus sound clip.
    /// </summary>
    private AudioSource bonusAudioSource;

    /// <summary>
    /// Audio source for a game over sound clip.
    /// </summary>
    private AudioSource gameOverAudioSource;

    // Use this for initialization
    void Awake()
    {
        if (AppleClip != null)
        {
            appleAudioSource = gameObject.AddAudio(AppleClip, false, false, 1f);
        }
        if (BonusClip != null)
        {
            bonusAudioSource = gameObject.AddAudio(BonusClip, false, false, 1f);
        }
        if (GameOverClip != null)
        {
            gameOverAudioSource = gameObject.AddAudio(GameOverClip, false, false, 1f);
        }
    }

    public void PlayAppleSoundEffect()
    {
        if (appleAudioSource != null)
        {
            appleAudioSource.Play();
        }
    }

    public void PlayBonusSoundEffect()
    {
        if (bonusAudioSource != null)
        {
            bonusAudioSource.Play();
        }
    }

    public void PlayGameOverSoundEffect()
    {
        if (gameOverAudioSource != null)
        {
            gameOverAudioSource.Play();
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        } else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void MutePressed()
    {
        if(muted == false)
        {
            // isMuted = !isMuted;
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
            soundOnIcon2.enabled = true;
            soundOffIcon2.enabled = false;
            soundOnIcon3.enabled = true;
            soundOffIcon3.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
            soundOnIcon2.enabled = false;
            soundOffIcon2.enabled = true;
            soundOnIcon3.enabled = false;
            soundOffIcon3.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
