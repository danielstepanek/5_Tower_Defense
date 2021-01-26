using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    }

	// Update is called once per frame
	private void OnParticleCollision(GameObject other)
	{
		print("I'm hit!");
        hitPoints--;

	}
	void Update()
    {
        if (hitPoints <= 0)
		{
			Destroy(gameObject);

		}
    }
}
