using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem goalParticle;
    [SerializeField] AudioClip goalFX;

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
		Transform body = transform.Find("Body");

    }


	IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        TriggerGoal();

    }
    void TriggerGoal()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);

        vfx.Play();
        var vfxAudio = vfx.GetComponent(typeof(AudioSource)) as AudioSource;
        vfxAudio.PlayOneShot(goalFX);

        Destroy(vfx.gameObject, 3.5f);

        Destroy(gameObject, 2f);
    }
}
