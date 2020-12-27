using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var finalPath = pathfinder.GetPath();
        StartCoroutine(FollowPath(finalPath));

    }
    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("On " + waypoint);
			yield return new WaitForSeconds(1f);
        }
	    print("Ending patrol.");
        
    }
}
