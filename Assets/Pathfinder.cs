using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();  
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    bool isRunning = true;
    Waypoint searchCenter;

    List<Waypoint> finalPath = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
	{
        LoadBlocks();
        BreadthFirstSearch();
        ColorStartAndEnd();
        BuildPath();
        return finalPath;
	}
    void BreadthFirstSearch()
	{
		{
            queue.Enqueue(startWaypoint);
            while (queue.Count > 0 && isRunning)
            {
                searchCenter = queue.Dequeue();
                searchCenter.isExplored = true;
                print(searchCenter);
                HaltIfEndFound();
                ExploreNeighbors();
            }
        }

	}
    void BuildPath()
	{
        finalPath.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
		{
			finalPath.Add(previous);
			previous = previous.exploredFrom;
		}
        finalPath.Add(startWaypoint);
        finalPath.Reverse();
        // add startwaypoint and reverse list
	}

	private void HaltIfEndFound()
	{
		if(searchCenter == endWaypoint)
		{
            isRunning = false;
		}
	}

	void LoadBlocks()
	{
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
		{
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
			{
                Debug.LogError("Overlapping block at " + gridPos);
			}
			else
			{
                grid.Add(gridPos, waypoint);
            } 
		}
    }
    void ExploreNeighbors()
	{
		if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
		{
            Vector2Int neighborCoords = searchCenter.GetGridPos() + direction;
            
			if(grid.ContainsKey(neighborCoords))
			{
                Waypoint neighbor = grid[neighborCoords];
                if (neighbor.isExplored == true || queue.Contains(neighbor))
                {
                    return;
                }
                else
                {
                    neighbor.SetTopColor(Color.blue);
                    print("queueing " + neighbor);
                    queue.Enqueue(neighbor);
                    neighbor.exploredFrom = searchCenter;
                }
            }
			
		}
	}
    void ColorStartAndEnd()
	{
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
