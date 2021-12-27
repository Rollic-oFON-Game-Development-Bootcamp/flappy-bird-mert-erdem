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
}
