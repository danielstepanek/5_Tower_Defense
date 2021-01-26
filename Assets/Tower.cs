using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform pivotingObject;
    [SerializeField] Transform enemyTarget;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;
    // Start is called before the first frame update
    void Start()
    {
        var enemies = FindObjectOfType<EnemyDamage>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget)
		{
            pivotingObject.LookAt(enemyTarget);
            FireAtEnemy();
        }
		else
		{
			Shoot(false);
		}
        
    }
    void FireAtEnemy()
	{
        float distanceToEnemy = Vector3.Distance(enemyTarget.transform.position, gameObject.transform.position);
		print(distanceToEnemy);

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
