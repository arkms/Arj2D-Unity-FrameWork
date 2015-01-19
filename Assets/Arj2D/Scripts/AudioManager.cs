using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }
    
    private static AudioSource Sound;
    private static AudioSource Background;
    public const string K_sound = "k_sound_fx";
    public const string K_music = "k_sound_back";

    public static void Init()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("AudioManager");
            instance =go.AddComponent<AudioManager>();
            go.isStatic = true;
            go.AddComponent<AudioListener>();
            Sound = go.AddComponent<AudioSource>();
            Sound.loop = false;
            Sound.playOnAwake = false;
            Background = go.AddComponent<AudioSource>();
            Background.priority = 255;
            Background.playOnAwake = false;
            Background.loop = true;
            int soundEnable = PlayerPrefs.GetInt(K_sound, 1);
            if (soundEnable == 0)
            {
                SetEnable_fx(false);
            }
            soundEnable = PlayerPrefs.GetInt(K_music, 1);
            if (soundEnable == 0)
            {
                SetEnable_music(false);
            }
        }
    }

    public static void SetEnable(bool _enable)
    {
        Sound.enabled = _enable;
        Background.enabled = _enable;
        if (Background.enabled)
        {
            Background.Play();
        }
    }

    public static void SetEnable_fx(bool _enable)
    {
        Sound.enabled = _enable;
    }

    //
    public static bool IsEnable_fx()
    {
        return Sound.enabled;
    }

    public static void Play(AudioClip _clip)
    {
        if(IsEnable_fx())
            Sound.PlayOneShot(_clip);
    }

    public static void Play(AudioClip _clip, float _pitch)
    {
        Sound.pitch = Random.Range(1f - _pitch, 1f + _pitch);
        Sound.PlayOneShot(_clip);
        Sound.pitch = 1f;
    }

    public static void ChangeVolumenSound(float _volumen)
    {
        Sound.volume= _volumen;
    }

    public static void Stop()
    {
        Sound.Stop();
    }


    // BackGround ------------------------------------------------------
    public static void PlayBackGround(AudioClip _clip)
    {
        if (Background.clip != _clip)
        {
            Background.Stop();
            Background.clip = _clip;
            Resources.UnloadUnusedAssets();
            if(Background.enabled)
                Background.Play();
        }
    }

    public static void SetEnable_music(bool _enable)
    {
        Background.enabled = _enable;
        if (Background.enabled)
        {
            Background.Play();
        }
    }

    public static void StopBackGround()
    {
        Background.Stop();
    }

    public static void ChangeVolumenBack(float _volumen)
    {
        Background.volume= _volumen;
    }

    public static bool IsEnableBack()
    {
        return Background.enabled;
    }
}
