using UnityEngine;

[SelectionBase]
public class Gate : MonoBehaviour
{
    [SerializeField] [Range(0f, 2f)] private float speed = 1f;

    private void Awake() => GameManager.ActionGameOver += Stop;

    private void Update() => Move();

    private void Move() => transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

    //action game over's method
    private void Stop() => Destroy(this);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GateDeadline"))
            Destroy(gameObject);
    }

    private void OnDestroy() => GameManager.ActionGameOver -= Stop;
}
