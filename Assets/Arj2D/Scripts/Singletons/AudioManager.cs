using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    private AudioSource Sound;
    private AudioSource Background;

    //A very simplea way o use this is only call
    /*
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
    private System.Collections.Generic.List<AudioSource> list_extraSnd;

    public void SetEnable(bool _enable)
    {
        SetEnable_fx(_enable);
        SetEnable_music(_enable);
    }

    public void SetEnable_fx(bool _enable)
    {
        Sound.enabled = _enable;
        //FreeAllsounds();
        PlayerPrefs.SetInt(K_sound, (_enable ? 1 : 0));
    }

    public bool IsEnable_fx()
    {
        return Sound.enabled;
    }

    public void Play(AudioClip _clip)
    {
        if(IsEnable_fx())
            Sound.PlayOneShot(_clip);
    }

    public void ChangeVolumenSound(float _volumen)
    {
        Sound.volume= _volumen;
    }

    public void StopAll()
    {
        Sound.Stop();
        Background.Stop();
        //StopAllSounds_PitchAndLoopsOnly();
    }


    // BackGround ------------------------------------------------------
    public void PlayMusic(AudioClip _clip)
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

    public void SetEnable_music(bool _enable)
    {
        Background.enabled = _enable;
        PlayerPrefs.SetInt(K_music, (_enable ? 1 : 0));
        if (Background.enabled)
        {
            Background.Play();
        }
    }

    public void StopMusic()
    {
        Background.Stop();
    }

    public void ChangeVolumenMusic(float _volumen)
    {
        Background.volume= _volumen;
    }

    public bool IsEnableMusic()
    {
        return Background.enabled;
    }

    public void PauseMusic()
    {
        Background.Pause();
    }

    public void UnPauseMusic()
    {
        Background.UnPause();
    }

    //--------------------------------------------LOOPSource and pitch (Extras) ALFA -------------------------------
    /// <summary>
    /// Play AudioClip in loop
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <returns>ID of audiosource</returns>
    public int PlaySound_Loop(AudioClip _clip)
    {
        if (IsEnable_fx())
        {
            int index = GetAudioSource();
            AudioSource audio = list_extraSnd[index];
            audio.loop = true;
            audio.volume = Sound.volume;
            audio.clip = _clip;
            audio.Play();
            return index;
        }
        return -1;
    }

    /// <summary>
    /// Play AudioClip in loop and start with volumen
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_volume">Volumen</param>
    /// <returns>ID of audiosource</returns>
    public int PlaySound_Loop(AudioClip _clip, float _volume)
    {
        if (IsEnable_fx())
        {
            int index = GetAudioSource();
            AudioSource audio = list_extraSnd[index];
            audio.loop = true;
            audio.clip = _clip;
            audio.volume = _volume;
            audio.Play();
            return index;
        }
        return -1;
    }

    /// <summary>
    /// Stop a AudioSource playing a clip
    /// </summary>
    /// <param name="_id">Id of AudioSource,, you can get it at play id=PlaySound_Loop(clip)</param>
    public void StopSound(int _id)
    {
        if (_id == -1) return;
        list_extraSnd[_id].Stop();
        list_extraSnd[_id].clip = null;
        list_extraSnd[_id].loop = false;
    }

    /// <summary>
    /// Stop all AudioClip in loop
    /// </summary>
    public void StopAllSounds_Loop()
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

    public void StopAllSounds_PitchAndLoopsOnly()
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
    public void FreeAllsounds()
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
    public void ChangeVolumen(int _id, float _volumen)
    {
        if (_id == -1) return;
        list_extraSnd[_id].volume = _volumen;
    }

    /// <summary>
    /// Play sound with pitch
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_pitch">float of pitch</param>
    public int Play_Pitch(AudioClip _clip, float _pitch)
    {
        if (IsEnable_fx())
        {
            int index = GetAudioSource();
            AudioSource audio = list_extraSnd[index];
            audio.clip = _clip;
            audio.pitch = _pitch;
            audio.volume = Sound.volume;
            audio.Play();
            return index;
        }
        return -1;
    }

    /// <summary>
    /// Play sound with pitch
    /// </summary>
    /// <param name="_clip">Clip to play</param>
    /// <param name="_pitch">float of pitch</param>
    /// <param name="_volume">volumne</param>
    public int Play_Pitch(AudioClip _clip, float _pitch, float _volume)
    {
        if (IsEnable_fx())
        {
            int index = GetAudioSource();
            AudioSource audio = list_extraSnd[index];
            audio.clip = _clip;
            audio.pitch = _pitch;
            audio.volume = _volume;
            audio.Play();
            return index;
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
    public int Play_Pitch(AudioClip _clip, float _pitch, float _delay, float _volume = -1f)
    {
        if (IsEnable_fx())
        {
            int index = GetAudioSource();
            AudioSource audio = list_extraSnd[index];
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
    private int GetAudioSource()
    {
        for (int i = 0; i < list_extraSnd.Count; i++)
        {
            if (!list_extraSnd[i].isPlaying)
            {
                list_extraSnd[i].pitch = 1.0f;
                list_extraSnd[i].volume = Sound.volume;
                return i;
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
            return list_extraSnd.Count-1;
        }

        //we add other
        AudioSource newAudioSource2 = Sound.transform.GetChild(0).gameObject.AddComponent<AudioSource>();
        newAudioSource2.playOnAwake = false;
        list_extraSnd.Add(newAudioSource2);
        return list_extraSnd.Count - 1;
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
        if (instance == null)
        {
            GameObject go = new GameObject("AudioManager");
            instance = go.AddComponent<AudioManager>();
            go.isStatic = true;
            if (Camera.main == null || Camera.main.GetComponent<AudioListener>() == null) //Just add AudiListener if is not already one
                go.AddComponent<AudioListener>();
            instance.Sound = go.AddComponent<AudioSource>();
            instance.Sound.loop = false;
            instance.Sound.playOnAwake = false;
            instance.Background = go.AddComponent<AudioSource>();
            instance.Background.priority = 255;
            instance.Background.playOnAwake = false;
            instance.Background.loop = true;
            int soundEnable = PlayerPrefs.GetInt(K_sound, 1);
            if (soundEnable == 0)
            {
                instance.Sound.enabled = false;
            }
            soundEnable = PlayerPrefs.GetInt(K_music, 1);
            if (soundEnable == 0)
            {
                instance.Background.enabled = false;
            }
            instance.list_extraSnd = new System.Collections.Generic.List<AudioSource>();
            DontDestroyOnLoad(go);
        }
    }
}
