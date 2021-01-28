using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hitFX;
    [SerializeField] AudioClip deathSFX;

    void Start()
    {
        audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
    }

	// Update is called once per frame
	private void OnParticleCollision(GameObject other)
	{
        hitPoints--;
        hitParticle.Play();
        audioSource.PlayOneShot(hitFX);
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
        var vfxAudio = vfx.GetComponent(typeof(AudioSource)) as AudioSource;
		vfxAudio.PlayOneShot(deathSFX);

        Destroy(vfx.gameObject, .75f);

        Destroy(gameObject);
    }
}
