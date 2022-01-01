using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform root;
    private Vector2 rootPos;
    private float posRefreshPoint;
    [SerializeField]
    [Range(0f, 2f)] [Tooltip("Must be same with Gate's speed")] private float speed = 1.35f;
    
    void Start()
    {
        GameManager.Instance.ActionGameOver += Stop;

        posRefreshPoint = boxCollider.size.x * -4f;
        rootPos = root.position;
    }

    void Update() => Move();

    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

        if (transform.localPosition.x <= posRefreshPoint)
            transform.localPosition = rootPos;
    }

    private void Stop()
    {
        GameManager.Instance.ActionGameOver -= Stop;
        Destroy(this);
    }
}
