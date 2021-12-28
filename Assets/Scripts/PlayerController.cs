using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] [Range(0.1f, 10f)] private float flyForce = 5f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fly();
    }

    private void Fly()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
            Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            Die();
    }

    private void Die()
    {
        
    }
}
