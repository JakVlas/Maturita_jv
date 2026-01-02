using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;               
    public int EnemiesPerBatch = 1;            
    public float SpawnInterval = 7f;           

    public void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        for (int n = 0; n < 5; n++) 
        {
            yield return new WaitForSeconds(SpawnInterval);


            for (int i = 0; i < EnemiesPerBatch; i++)
            {
                Vector3 spawnPosition = (Vector3)gameObject.transform.position;

                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
       
}
