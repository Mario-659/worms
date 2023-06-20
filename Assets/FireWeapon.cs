using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float minimalBulletForce = 5f;
    public float maximumBulletForce = 25f;
    public float addedBulletForce = 0.05f;
    public float cooldownTime = 1f;
    public float rotationSpeed = 5f;
    private float cooldownTimer = 0f;
    private float bulletForce = 0f;
    // Update is called once per frame

    void Start()
    {
        bulletForce = minimalBulletForce;
    }
    void Update()
    {
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            if (bulletForce < maximumBulletForce)
            {
                bulletForce += addedBulletForce;
            }
        }

        if (Input.GetMouseButtonUp(0) && cooldownTimer <= 0f)
        {
            Fire();
            cooldownTimer = cooldownTime;
            bulletForce = minimalBulletForce;
        }
    }

    void Fire()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Rotate the bullet's direction
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // Apply a force to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.right * bulletForce, ForceMode2D.Impulse);
        
        // Destroy the bullet after a certain time (optional)
        Destroy(bullet, 2f);
    }
}
