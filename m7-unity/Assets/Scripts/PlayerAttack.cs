using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform shootPoint; 
    public float fireRate = 1.5f; 
    public float projectileSpeed = 20f; 
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime) 
        {
            Transform target = FindClosestEnemy(); 
            if (target != null)
            {
                Shoot(target);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (target.position - shootPoint.position).normalized; 
                rb.linearVelocity = direction * projectileSpeed; 
            }
        }
    }

    // Busca el enemigo m�s cercano
    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        Transform closestEnemy = null;
        float minDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(currentPosition, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy.transform;
            }
        }

        return closestEnemy; 
    }
}
