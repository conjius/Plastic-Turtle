using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> _enemies;
    public GameObject spawner;
    public GameObject enemyPrefab;
    public float enemySpawnInterval;
    public float enemyspeed;

    private GameTimer _spawnTimer;

    private void Start()
    {
        _enemies = new List<GameObject>();
        _spawnTimer = gameObject.AddComponent<GameTimer>();
        _spawnTimer.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_spawnTimer.HasElapsed(enemySpawnInterval)) SpawnEnemy();
        foreach (var enemy in _enemies)
        {
            enemy.transform.Translate(enemyspeed * Vector3.down);
        }
    }

    private void SpawnEnemy()
    {
        var position = spawner.transform.position;
        var spawnLocation = new Vector3(Random.Range(-2, 2),
            position.y, position.y);
        var newEnemy = Instantiate(enemyPrefab, transform);
        newEnemy.transform.position = spawnLocation;
        _enemies.Insert(_enemies.Count, newEnemy);
    }
}