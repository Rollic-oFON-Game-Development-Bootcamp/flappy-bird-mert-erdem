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

    private void Start()
    {
        GameManager.Instance.ActionGameOver += Stop;
        GameManager.Instance.ActionGameStart += StartSpawning;

        upperBound = spawnBoundUpper.position.y;
        lowerBound = spawnBoundLower.position.y;
    }

    private void SpawnGate()
    {
        float spawnPointY = Random.Range(lowerBound, upperBound);
        var spawnPoint = new Vector2(spawnPointX, spawnPointY);
        Instantiate(gate, spawnPoint, Quaternion.identity);
    }

    //action game start's method
    private void StartSpawning()
    {
        InvokeRepeating("SpawnGate", spawnStartTime, spawnIntervalTime);
    }

    //action game over's method
    private void Stop() => CancelInvoke("SpawnGate");

    private void OnDestroy()
    {
        GameManager.Instance.ActionGameOver -= Stop;
        GameManager.Instance.ActionGameStart -= StartSpawning;
    }
}
