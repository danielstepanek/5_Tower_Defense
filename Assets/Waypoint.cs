using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPos;
    void Start()
    {
        
    }
    public int GetGridSize()
	{
        return gridSize;
    }
    public Vector2Int GetGridPos()
	{
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
    public void SetTopColor(Color color)
	{
		MeshRenderer top = transform.Find("Top").GetComponent<MeshRenderer>();
        top.material.color = color;
        
	}

    void Update()
    {
        
    }
}
