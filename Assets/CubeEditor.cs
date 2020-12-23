using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(0f, 20f)] float gridSize = 10f;
    TextMesh textMesh;    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x/10f) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z/10f) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = transform.position.x + "," + transform.position.z;
    }
}
