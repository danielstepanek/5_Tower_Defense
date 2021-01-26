using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float secondsBetweenSpawns = 1f;
    [SerializeField] GameObject enemyPreFab;
    public int numOfEnemies = 5;
    void Start()
    {
		StartCoroutine("SpawnEnemy", enemyPreFab);
    }
    IEnumerator SpawnEnemy(GameObject enemy)
	{
        while (numOfEnemies > 0)
		{
            Instantiate(enemyPreFab, gameObject.transform.position, Quaternion.identity);
            numOfEnemies--;
            yield return new WaitForSeconds(1f);
        }
        
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
