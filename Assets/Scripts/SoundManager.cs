using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField]
    private AudioSource musicPlayer;
    [SerializeField]
    private AudioSource sfxPlayer;
    [SerializeField]
    private SoundConfig soundConfig;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        PlayerGameMusic();



    }

    public float lastCheckedTime = -1.0f;  // To keep track of the last checked game time





    public void PlayerMenuMusic()
    {
        musicPlayer.clip = soundConfig.menuMusic.clip;
        musicPlayer.volume = soundConfig.menuMusic.volume;
        musicPlayer.loop = soundConfig.menuMusic.loop;
        musicPlayer.Play();
    }

    public void StopMenuMusic()
    {

        musicPlayer.Stop();
    }



    public void PlayerGameMusic()
    {
        musicPlayer.clip = soundConfig.gameMuisc.clip;
        musicPlayer.volume = soundConfig.gameMuisc.volume;
        musicPlayer.loop = soundConfig.gameMuisc.loop;
        musicPlayer.Play();
    }

    public void StopGameMusic()
    {

        musicPlayer.Stop();
    }

    public void PlayerGameMusicFast()
    {
        musicPlayer.clip = soundConfig.gameMuisc.clip;
        musicPlayer.pitch = 1.5f;
        musicPlayer.volume = soundConfig.gameMuisc.volume;
        musicPlayer.loop = soundConfig.gameMuisc.loop;
        musicPlayer.Play();
    }

    public void StopGameMusicFast()
    {
        musicPlayer.Stop();
    }

    public void PlayerGrabSound()
    {
        sfxPlayer.clip = soundConfig.grabSound.clip;
        sfxPlayer.volume = soundConfig.grabSound.volume;
        sfxPlayer.loop = soundConfig.grabSound.loop;
        sfxPlayer.Play();
    }
    public void StopGrabSound()
    {
        sfxPlayer.Play();
    }

    public void PlayerChopSound()
    {
        sfxPlayer.clip = soundConfig.chopSound.clip;
        sfxPlayer.volume = soundConfig.chopSound.volume;
        sfxPlayer.loop = soundConfig.chopSound.loop;
        sfxPlayer.Play();
    }

    public void StopChopSound()
    {
        sfxPlayer.Stop();
    }

    public void PlayerWalkSound()
    {
        sfxPlayer.clip = soundConfig.walkSound.clip;
        sfxPlayer.volume = soundConfig.walkSound.volume;
        sfxPlayer.loop = soundConfig.walkSound.loop;
        sfxPlayer.Play();
    }

    public void StopWalkSound()
    {
        sfxPlayer.Stop();
    }

    public void PlayRightSound()
    {
        sfxPlayer.clip = soundConfig.rightSound.clip;
        sfxPlayer.volume = soundConfig.rightSound.volume;
        sfxPlayer.loop = soundConfig.rightSound.loop;
        sfxPlayer.Play();
    }

    public void PlayWrongSound()
    {
        sfxPlayer.clip = soundConfig.wrongSound.clip;
        sfxPlayer.volume = soundConfig.wrongSound.volume;
        sfxPlayer.loop = soundConfig.wrongSound.loop;
        sfxPlayer.Play();
    }
    public void PlaySuccessSound()
    {
        sfxPlayer.clip = soundConfig.sucessSound.clip;
        sfxPlayer.volume = soundConfig.sucessSound.volume;
        sfxPlayer.loop = soundConfig.sucessSound.loop;
        sfxPlayer.Play();
    }

    public void PlayFailureSound()
    {
        sfxPlayer.clip = soundConfig.failureSound.clip;
        sfxPlayer.volume = soundConfig.failureSound.volume;
        sfxPlayer.loop = soundConfig.failureSound.loop;
        sfxPlayer.Play();
    }

    public void PlayWarningSound()
    {
        sfxPlayer.clip = soundConfig.warningSound.clip;
        sfxPlayer.volume = soundConfig.warningSound.volume;
        sfxPlayer.loop = soundConfig.warningSound.loop;
        sfxPlayer.Play();
    }

    public void PlayEndingSound()
    {
        sfxPlayer.clip = soundConfig.endingSound.clip;
        sfxPlayer.volume = soundConfig.endingSound.volume;
        sfxPlayer.loop = soundConfig.endingSound.loop;
        sfxPlayer.Play();

    }

    public void PlayFinalSound()
    {
        sfxPlayer.clip = soundConfig.finalSound.clip;
        sfxPlayer.volume = soundConfig.finalSound.volume;
        sfxPlayer.loop = soundConfig.finalSound.loop;
        sfxPlayer.Play();

    }

    public void PlayJumpSound()
    {
        sfxPlayer.clip = soundConfig.jumpSound.clip;
        sfxPlayer.volume = soundConfig.jumpSound.volume;
        sfxPlayer.loop = soundConfig.jumpSound.loop;
        sfxPlayer.time = 0.2f;
        sfxPlayer.Play();

    }

    public void DestroyInstance()
    {
        Destroy(gameObject);
        Instance = null;
    }



}
