using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int spawnAmount;
    [SerializeField] private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyPrefab, spawnAmount, spawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemy(GameObject enemy, int amount, float interval){
        for(int i = 0; i < amount; i++){
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0), Quaternion.identity, transform);
            yield return new WaitForSeconds(interval);
        }
    }

    public void startSpawnEnemy(){
        StartCoroutine(spawnEnemy(enemyPrefab, spawnAmount, spawnInterval));
    }

    public void destroyAllEnemy(){
        while(transform.childCount > 0){
            GameObject childEnemyGameObject = transform.GetChild(0).gameObject;
            Destroy(childEnemyGameObject);
        }
    }
}
