using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    
    void Start()
    {
        AudioSource aSource = GetComponent<AudioSource>();
        aSource.clip = AudioBehaviour.Instance.clipList[AudioClips.Music];
        aSource.Play();
        aSource.loop = true;    
    }

   
}
