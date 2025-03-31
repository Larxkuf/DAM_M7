using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Daño que causa la bala

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player")) // Verifica si impacta al jugador
            {
                CubeMovement player = collision.gameObject.GetComponent<CubeMovement>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
            }

            Destroy(gameObject); // Destruye la bala tras el impacto

        
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Enemigo golpeado"); // Imprime un mensaje de debu
                }

                Destroy(gameObject); // Destruye la bala
            }
            else
            {
                Destroy(gameObject, 3f); // Destruye la bala tras 3 segundos si no golpea nada
            }
        

    }

}

