using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Block> path;

    void Start()
    {
        PrintWaypoints();
    }
    void PrintWaypoints()
    {
        foreach (Block waypoint in path)
        {
            print(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
