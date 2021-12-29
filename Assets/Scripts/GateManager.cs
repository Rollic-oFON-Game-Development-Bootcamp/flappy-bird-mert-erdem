using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    
    [Header("Spawning Specs")]
    [SerializeField] private Transform spawnBoundUpper;
    [SerializeField] private Transform spawnBoundLower;
    [SerializeField] private float spawnStartTime = 1f;
    [SerializeField] private float spawnIntervalTime = 5f;
    private float upperBound, lowerBound;
    private float spawnPointX = 5f;

    private void Awake() => GameManager.ActionGameOver += Stop;

    private void Start()
    {
        upperBound = spawnBoundUpper.position.y;
        lowerBound = spawnBoundLower.position.y;

        InvokeRepeating("SpawnGate", spawnStartTime, spawnIntervalTime);
    }

    private void SpawnGate()
    {
        float spawnPointY = Random.Range(lowerBound, upperBound);
        var spawnPoint = new Vector2(spawnPointX, spawnPointY);
        Instantiate(gate, spawnPoint, Quaternion.identity);
    }

    //action game over's method
    private void Stop() => Destroy(gameObject);

    private void OnDestroy() => GameManager.ActionGameOver -= Stop;
}
