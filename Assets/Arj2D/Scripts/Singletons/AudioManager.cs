using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    private static AudioSource Sound;
    private static AudioSource Background;

    //A very simplea way o use this is only call
    /*
     * Init()
     * Play(audioclip)
     * PlayMusic(audioclip)
     * StopMusic()
     * SetEnable_music(true or false)
     * SetEnable_fx(true or false)
     */

    /// <summary>
    /// Key for save sound or fx with PlayerPrefs
    /// </summary>
    public const string K_sound = "k_sound_fx";
    /// <summary>
    /// Key for save music or background with PlayerPrefs
    /// </summary>
    public const string K_music = "k_sound_back";
    /// <summary>
    /// List of AudioSource in case we need play sounds of fx with loop // or pitch? (TODO)
    /// </summary>
    private static System.Collections.Generic.List<AudioSource> list_extraSnd;

    public static void Init()
    {
        if (instance == null)
        {
            GameObject go = new GameObject("AudioManager");
            instance =go.AddComponent<AudioManager>();
            go.isStatic = true;
            if(Camera.main == null || Camera.main.GetComponent<AudioListener>() == null) //Just add AudiListener if is not already one
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
            list_extraSnd = new System.Collections.Generic.List<AudioSource>();
            DontDestroyOnLoad(go);
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
        FreeAllsounds();
        PlayerPrefs.SetInt(K_sound, (_enable ? 1 : 0));
    }

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

    public static void StopAll()
    {
        Sound.Stop();
        Background.Stop();
        StopAllSounds_PitchAndLoopsOnly();
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

    public static void PauseMusic()
    {
        Background.Pause();
    }

    public static void UnPauseMusic()
    {
        Background.UnPause();
    }

    //--------------------------------------------LOOPSource and pitch (Extras) -------------------------------

    /// <summary>
    /// Play AudioClip in loop
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <returns>ID of audiosource</returns>
    public static int PlaySound_Loop(AudioClip _clip)
    {
        if (IsEnable_fx())
        {
            AudioSource audio = GetAudioSource();
            audio.loop = true;
            audio.volume = Sound.volume;
            audio.clip = _clip;
            audio.Play();
            return list_extraSnd.IndexOf(audio);
        }
        return -1;
    }

    /// <summary>
    /// Play AudioClip in loop and start with volumen
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_volume">Volumen</param>
    /// <returns>ID of audiosource</returns>
    public static int PlaySound_Loop(AudioClip _clip, float _volume)
    {
        if (IsEnable_fx())
        {
            AudioSource audio = GetAudioSource();
            audio.loop = true;
            audio.clip = _clip;
            audio.volume = _volume;
            audio.Play();
            return list_extraSnd.IndexOf(audio);
        }
        return -1;
    }

    /// <summary>
    /// Stop a AudioSource playing a clip
    /// </summary>
    /// <param name="_clip">Clip to stop</param>
    public static void StopSound_Loop(AudioClip _clip)
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            if (list_extraSnd[i].isPlaying && list_extraSnd[i].clip == _clip && list_extraSnd[i].loop)
            {
                list_extraSnd[i].Stop();
                list_extraSnd[i].clip = null;
                list_extraSnd[i].loop = false;
                return;
            }
        }
        Debug.LogWarning(_clip + " is not in loop");
    }

    /// <summary>
    /// Stop a AudioSource playing a clip
    /// </summary>
    /// <param name="_id">Id of AudioSource,, you can get it at play id=PlaySound_Loop(clip)</param>
    public static void StopSound(int _id)
    {
        if (_id == -1) return;
        list_extraSnd[_id].Stop();
        list_extraSnd[_id].clip = null;
        list_extraSnd[_id].loop = false;
    }

    /// <summary>
    /// Stop all AudioClip in loop
    /// </summary>
    public static void StopAllSounds_Loop()
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            if (list_extraSnd[i].loop)
            {
                list_extraSnd[i].Stop();
                list_extraSnd[i].clip = null;
                list_extraSnd[i].loop = false;
            }
        }
    }

    public static void StopAllSounds_PitchAndLoopsOnly()
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            list_extraSnd[i].Stop();
            list_extraSnd[i].clip = null;
            list_extraSnd[i].loop = false;
        }
    }

    /// <summary>
    /// Stop and release all AudioSourcewith loop and pitch
    /// </summary>
    public static void FreeAllsounds()
    {
        if (list_extraSnd.Count > 0)
        {

            GameObject go = list_extraSnd[0].gameObject;
            for (int i = 0; i < list_extraSnd.Count; i++)
            {
                list_extraSnd[i].Stop();
                list_extraSnd[i].clip = null;
                Destroy(list_extraSnd[i]);
            }

            Destroy(go);
            list_extraSnd.Clear();
        }
    }

    /// <summary>
    /// Change Volume of specific AudioSource with loop
    /// </summary>
    /// <param name="_id">id of audiosource you can get it at play id=PlaySound_Loop(clip)</param>
    /// <param name="_volumen">Volumen between 0.0f - 1.0f</param>
    public static void ChangeVolumen(int _id, float _volumen)
    {
        if (_id == -1) return;
        list_extraSnd[_id].volume = _volumen;
    }

    /// <summary>
    /// Change Volume of specific AudioSource with loop,, this only for this play
    /// </summary>
    /// <param name="_volumen">Volumen between 0.0f - 1.0f</param>
    public static void ChangeVolumen_LoopAll(float _volumen)
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            if (list_extraSnd[i].loop)
                list_extraSnd[i].volume = _volumen;
        }
    }

    /// <summary>
    /// Play sound with pitch
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_pitch">float of pitch</param>
    public static int Play_Pitch(AudioClip _clip, float _pitch)
    {
        if (IsEnable_fx())
        {
            AudioSource audio = GetAudioSource();
            audio.clip = _clip;
            audio.pitch = _pitch;
            audio.volume = Sound.volume;
            audio.Play();
            return list_extraSnd.IndexOf(audio);
        }
        return -1;
    }

    /// <summary>
    /// Play sound with pitch
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_pitch">float of pitch</param>
    /// <param name="_volume">volumne</param>
    public static int Play_Pitch(AudioClip _clip, float _pitch, float _volume)
    {
        if (IsEnable_fx())
        {
            AudioSource audio = GetAudioSource();
            audio.clip = _clip;
            audio.pitch = _pitch;
            audio.volume = _volume;
            audio.Play();
            return list_extraSnd.IndexOf(audio);
        }
        return -1;
    }

    /// <summary>
    /// Play sound with pitch
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_pitch">float of pitch</param>
    /// <param name="_delay">delay to play</param>
    /// <param name="_volume">volumen</param>
    public static int Play_Pitch(AudioClip _clip, float _pitch, float _delay, float _volume = -1f)
    {
        if (IsEnable_fx())
        {
            AudioSource audio = GetAudioSource();
            audio.clip = _clip;
            audio.pitch = _pitch;
            audio.volume = (_volume == -1) ? Sound.volume : _volume;
            audio.PlayDelayed(_delay);
            return list_extraSnd.IndexOf(audio);
        }
        return -1;
    }

    /// <summary>
    /// Get one Audiosource that is not in use or create it
    /// </summary>
    private static AudioSource GetAudioSource()
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            if (!list_extraSnd[i].isPlaying)
            {
                list_extraSnd[i].pitch = 1.0f;
                list_extraSnd[i].volume = Sound.volume;
                return list_extraSnd[i];
            }
        }

        //we create GameObject that containt it
        if (list_extraSnd.Count == 0)
        {
            GameObject go = new GameObject("Sound_Loop");
            go.transform.parent = Sound.transform;
            go.isStatic = true;
            AudioSource newAudioSource = go.AddComponent<AudioSource>();
            newAudioSource.playOnAwake = false;
            list_extraSnd.Add(newAudioSource);
            return newAudioSource;
        }

        //we add other
        AudioSource newAudioSource2 = Sound.transform.GetChild(0).gameObject.AddComponent<AudioSource>();
        newAudioSource2.playOnAwake = false;
        list_extraSnd.Add(newAudioSource2);
        return newAudioSource2;
    }

    private static AudioManager instance = null;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod]
    public static void OnLoad()
    {
        Init();
    }
}
