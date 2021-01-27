using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;


    void Start()
    {
        
    }

	// Update is called once per frame
	private void OnParticleCollision(GameObject other)
	{
        hitPoints--;
        hitParticle.Play();

	}
	void Update()
    {
        if (hitPoints <= 0)
		{
            TriggerDeath();
		}
    }
    void TriggerDeath()
    {

        var vfx = Instantiate(deathParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);

    }
}
