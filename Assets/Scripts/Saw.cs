using System.Collections.Generic;
using UnityEngine;

public class SawPathFollower : MonoBehaviour
{

    public List<Transform> points;


    public float speed = 5f;

    private int index = 0;
    [SerializeField] private bool allowSound = false;

    private void OnEnable()
    {
        SawSoundEnabler.OnAllowSawSound += AllowSawSound;
    }
    private void OnDisable()
    {
        SawSoundEnabler.OnAllowSawSound -= AllowSawSound;
    }

    void Update()
    {
       
        if (points == null || points.Count == 0)
            return;


        Transform objetive = points[index];


        transform.position = Vector3.MoveTowards(
            transform.position,
            objetive.position,
            speed * Time.deltaTime
        );


        if (Vector3.Distance(transform.position, objetive.position) < 0.05f)
        {
            index++;


            if (index >= points.Count)
                index = 0;
        }
    }
    public void AllowSawSound()
    {
        allowSound = !allowSound;
    }
    public void Restart()
    {
        if (allowSound)
        {
            AudioSource aSource = GetComponent<AudioSource>();
            aSource.clip = AudioBehaviour.Instance.clipList[AudioClips.Saw];
            aSource.loop = true;
            aSource.Play();
        }
        transform.position = points[0].position;
        index = 0;
    }
}
