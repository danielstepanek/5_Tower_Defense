using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform pivotingObject;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] Vector3 targetingOffset;

    Transform enemyTarget;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (enemyTarget)
		{
            pivotingObject.LookAt(enemyTarget.position + targetingOffset);
            FireAtEnemy();
        }
		else
		{
			Shoot(false);
		}
        
    }
    void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0)
        {
            return;
        }
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        enemyTarget = closestEnemy;
    }
    public Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        float firstEnemyDist = Vector3.Distance(transform.position, closestEnemy.position);
        float newDist = Vector3.Distance(transform.position, testEnemy.position);
        if ( newDist < firstEnemyDist)
        {
            return testEnemy;
        }
        else
        {
            return closestEnemy;
        }
    }
    void FireAtEnemy()
	{
        float distanceToEnemy = Vector3.Distance(enemyTarget.transform.position, gameObject.transform.position);


        if (distanceToEnemy <= attackRange)
		{
            Shoot(true);
		}
		else
		{
            Shoot(false);
		}
	}
    void Shoot(bool isActive)
	{
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
	}
}
