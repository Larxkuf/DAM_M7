using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; 
    public float jumpForce = 7f; 
    private Rigidbody _rb;
    private bool _isGrounded;

    public int maxHealth = 100;
    private int currentHealth;
    private Renderer _renderer; 

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        currentHealth = maxHealth;
        UpdateColor();
    }

    void Update()
    {
  
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(moveX, _rb.linearVelocity.y, moveZ);
        _rb.linearVelocity = new Vector3(movement.x, _rb.linearVelocity.y, movement.z);


        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); 
        UpdateColor();

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void UpdateColor()
    {
        if (currentHealth > 70)
            _renderer.material.color = Color.green;
        else if (currentHealth > 40)
            _renderer.material.color = Color.yellow;
        else
            _renderer.material.color = Color.red;
    }


    private void Die()
    {
        Debug.Log("¡Jugador eliminado!");

    }
}
