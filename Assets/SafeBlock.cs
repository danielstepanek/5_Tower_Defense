using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBlock : MonoBehaviour
{
    [SerializeField] bool hasTower = false;
    [SerializeField] Vector3 towerOffset;
    [SerializeField] Tower tower;
    void Start()
    {

    }
    private void OnMouseOver()
    {
        if (hasTower == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("Clicked " + transform.position.x + " " + transform.position.z);
                SpawnTower();
                hasTower = true;
            }
        }
    }
    void SpawnTower()
    {
        Instantiate(tower, transform.position + towerOffset, Quaternion.identity);
        hasTower = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
