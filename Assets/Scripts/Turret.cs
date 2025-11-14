using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint; 
    [SerializeField] private float fireRate = 1.5f; 
    [SerializeField] private float projectileSpeed = 10f;

    private void Start()
    {
        StartCoroutine(ShootRoutine());
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

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.linearVelocity = shootPoint.right * projectileSpeed;
    }
}