using UnityEngine;

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
                Sound.enabled = false;
            }
            soundEnable = PlayerPrefs.GetInt(K_music, 1);
            if (soundEnable == 0)
            {
                Background.enabled = false;
            }
        }
    }

    public static void SetEnable(bool _enable)
    {
        SetEnable_fx(_enable);
        SetEnable_music(_enable);
    }

    public static void SetEnable_fx(bool _enable)
    {
        Sound.enabled = _enable;
        PlayerPrefs.SetInt(K_sound, (_enable ? 1 : 0));
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

    public static void ChangeVolumenSound(float _volumen)
    {
        Sound.volume= _volumen;
    }

    public static void Stop()
    {
        Sound.Stop();
    }


    // BackGround ------------------------------------------------------
    public static void PlayMusic(AudioClip _clip)
    {
        if (Background.clip != _clip)
        {
            Background.Stop();
            Background.clip = _clip;
            //Resources.UnloadUnusedAssets();
            if(Background.enabled)
                Background.Play();
        }
    }

    public static void SetEnable_music(bool _enable)
    {
        Background.enabled = _enable;
        PlayerPrefs.SetInt(K_music, (_enable ? 1 : 0));
        if (Background.enabled)
        {
            Background.Play();
        }
    }

    public static void StopMusic()
    {
        Background.Stop();
    }

    public static void ChangeVolumenMusic(float _volumen)
    {
        Background.volume= _volumen;
    }

    public static bool IsEnableMusic()
    {
        return Background.enabled;
    }
}
