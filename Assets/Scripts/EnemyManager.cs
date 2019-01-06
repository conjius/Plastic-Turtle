using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies;
    public GameObject spawner;
    public GameObject enemyPrefab;
    public float enemySpawnInterval;
    public float enemyspeed;

    private GameTimer _spawnTimer;

    private void Start()
    {
        enemies = new List<GameObject>();
        _spawnTimer = gameObject.AddComponent<GameTimer>();
        _spawnTimer.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_spawnTimer.HasElapsed(enemySpawnInterval)) SpawnEnemy();
        foreach (var enemy in enemies)
        {
            enemy.transform.Translate(enemyspeed * Vector3.down);
        }
    }

    private void SpawnEnemy()
    {
        var position = spawner.transform.position;
        var spawnLocation = new Vector3(Random.Range(-2, 2),
            position.y, position.z);
        var newEnemy = Instantiate(enemyPrefab, transform);
        newEnemy.transform.position = spawnLocation;
        enemies.Insert(enemies.Count, newEnemy);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }
}