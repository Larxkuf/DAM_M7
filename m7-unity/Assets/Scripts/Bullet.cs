using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                CubeMovement player = collision.gameObject.GetComponent<CubeMovement>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }

            Destroy(gameObject);

        
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Enemigo golpeado");
                }

                Destroy(gameObject); 
            }
            else
            {
                Destroy(gameObject, 3f); 
            }
        

    }

}

