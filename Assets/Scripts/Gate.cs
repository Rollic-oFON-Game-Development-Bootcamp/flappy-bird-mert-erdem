using UnityEngine;

[SelectionBase]
public class Gate : MonoBehaviour
{
    [SerializeField] [Range(0f, 2f)] private float speed = 1f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GateDeadline"))
            Destroy(gameObject);
    }
}
