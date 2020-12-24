using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	Waypoint waypoint;
    void Awake()

    {
		waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
	{
		SnapToGrid();
		UpdateLabel();
	}

	private void SnapToGrid()
	{
		int gridSize = waypoint.GetGridSize();
		transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
	}

	private void UpdateLabel()
	{
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
		gameObject.name = labelText;
		textMesh.text = labelText;
	}
}
