using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;



public enum AudioClips
{
    Teleport,
    Shoot,
    Music,
    Saw
}
public class AudioBehaviour : MonoBehaviour
{
    public static AudioBehaviour Instance;
    [SerializeField] private List<AudioClip> _clip = new List<AudioClip>();
    public Dictionary<AudioClips, AudioClip> clipList = new Dictionary<AudioClips, AudioClip>();

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
        }

        clipList.Add(AudioClips.Teleport, _clip[0]);
        clipList.Add(AudioClips.Shoot, _clip[1]);
        clipList.Add(AudioClips.Music, _clip[2]);
        clipList.Add(AudioClips.Saw, _clip[3]);
    }
   
}


