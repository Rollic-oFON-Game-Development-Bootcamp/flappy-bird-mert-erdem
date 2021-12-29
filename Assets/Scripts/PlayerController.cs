using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //components
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    //specs
    [SerializeField] [Range(0.1f, 10f)] private float flyForce = 5f;

    private void Awake() => GameManager.ActionGameOver += Die;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Fly();
    }

    private void FixedUpdate() => Rotate();

    private void Fly()
    {
        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(Vector2.up * flyForce, ForceMode2D.Impulse);
    }

    private void Rotate()
    {
        float rotationZ = Mathf.Clamp(rigidBody.velocity.y * 25f, -50f, 30f);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    //action game over's method
    private void Die()
    {
        animator.enabled = false;
        transform.rotation = Quaternion.Euler(0f, 0f, -50f);
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
            GameManager.ActionGameOver?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            GameManager.ActionGameOver?.Invoke();
    }

    private void OnDestroy() => GameManager.ActionGameOver -= Die;
}
