using UnityEngine;
using System.Collections;
using System;

public class Turret : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint; 
    [SerializeField] private float fireRate = 1.5f; 
    [SerializeField] private float projectileSpeed = 10f;
    
    [SerializeField] private bool permitirDisparar = false;


    private void Start()
    {
        StartCoroutine(ShootRoutine());
    }


    private void OnEnable()
    {
        SoundEnabler.OnPermitirDispararChanged += CambiarEstadoDisparo;
        SawSoundEnabler.OnPermitirDispararChanged += CambiarEstadoDisparo;  

    }

    private void OnDisable()
    {
        SoundEnabler.OnPermitirDispararChanged -= CambiarEstadoDisparo;
        SawSoundEnabler.OnPermitirDispararChanged -= CambiarEstadoDisparo;
    }

    private void CambiarEstadoDisparo()
    {
        permitirDisparar = !permitirDisparar;
    }
    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }

    private void Shoot()
    {
        
        if (permitirDisparar)
        {
            AudioSource aSource = GetComponent<AudioSource>();
            aSource.clip = AudioBehaviour.Instance.clipList[AudioClips.Shoot];
            aSource.Play();
        }
       

        GameObject projectile = BulletPool.Instance.GetBullet();
        projectile.transform.position = shootPoint.position;
        projectile.transform.rotation = shootPoint.rotation;
        projectile.SetActive(true);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootPoint.right * projectileSpeed;
    }
}