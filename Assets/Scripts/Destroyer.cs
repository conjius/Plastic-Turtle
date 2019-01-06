using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject enemyManagerObject;
    private EnemyManager _enemyManager;

    private void Start()
    {
        _enemyManager = enemyManagerObject.GetComponent<EnemyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("blah");
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("Enemy"))
        {
            _enemyManager.DestroyEnemy(otherGameObject);
        }
    }
}