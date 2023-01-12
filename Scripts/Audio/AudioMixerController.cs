using UnityEngine;
using UnityEngine.Audio;
using Arj2D;

public class AudioMixerController : MonoBehaviour
{
    public enum Group {Master, Background, Effects}

    private const string kMasterVolume = "MasterVolume";
    private const string kMusicVolume = "MusicVolume";
    private const string kEffectVolume = "EffectVolume";

    private float _masterLastVolume = 1f;
    private float _musicLastVolume = 1f;
    private float _effectLastVolume = 1f;
    private bool _masterMute = false;
    private bool _musicMute = false;
    private bool _effectMute = false;

    [SerializeField] AudioMixer audioMixer = null;

    [SerializeField] AudioMixerGroup[] groups = null;

    public static AudioMixerController Instance { get; private set; }

    #region API

    public AudioMixerGroup GetGroup(Group _group)
    {
        return groups[_group.ToInt()];
    }
    public AudioMixerGroup GetGroup(int _groupID)
    {
        return groups[_groupID];
    }
    #endregion

    #region MASTER

    public void Master_SetVolumen(float newVolumen)
    {
        if (!_masterMute)
        {
            if(newVolumen > 0f)
                audioMixer.SetFloat(kMasterVolume, Mathf.Lerp(-35f, 0f, newVolumen)); // After -35, the sound is almost mute
            else
                audioMixer.SetFloat(kMasterVolume, -80f);
        }
        else
            _masterLastVolume = newVolumen;
    }

    public void Master_SetMute(bool mute)
    {
        if (mute)
            audioMixer.GetFloat(kMasterVolume, out _masterLastVolume); // backup volumen before mute
        Master_SetVolumen(mute ? 0f : _masterLastVolume);
        _masterMute = mute;
    }

    #endregion

    #region MUSIC

    public void Music_SetVolumen(float newVolumen)
    {
        if (newVolumen > 0f)
            audioMixer.SetFloat(kMusicVolume, Mathf.Lerp(-35f, 0f, newVolumen)); // After -35, the sound is almost mute
        else
            audioMixer.SetFloat(kMusicVolume, -80f);
    }

    public void Music_SetMute(bool mute)
    {
        if (mute)
            audioMixer.GetFloat(kMusicVolume, out _musicLastVolume); // backup volumen before mute
        Music_SetVolumen(mute ? 0f : _musicLastVolume);
        _musicMute = mute;
    }

    #endregion

    #region EFFECT

    public void Effect_SetVolumen(float newVolumen)
    {
        if (newVolumen > 0f)
            audioMixer.SetFloat(kEffectVolume, Mathf.Lerp(-35f, 0f, newVolumen)); // After -35, the sound is almost mute
        else
            audioMixer.SetFloat(kEffectVolume, -80f);
    }

    public void Effect_SetMute(bool mute)
    {
        if (mute)
            audioMixer.GetFloat(kEffectVolume, out _effectLastVolume); // backup volumen before mute
        Music_SetVolumen(mute ? 0f : _effectLastVolume);
        _effectMute = mute;
    }

    #endregion

    private void Awake()
    {
        Instance = this;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void AutoInit()
    {
        GameObject go = Resources.Load<GameObject>("_AudioMixerMasterManager");
        go =Instantiate(go);
        DontDestroyOnLoad(go);
    }
}
