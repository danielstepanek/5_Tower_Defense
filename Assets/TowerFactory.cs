using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Vector3 towerOffset;
    public void AddTower(SafeBlock safeBlock)
    {
        var towers = FindObjectsOfType<Tower>();
        if (towers.Length < towerLimit)
        {
            print("Clicked " + safeBlock.transform.position.x + " " + safeBlock.transform.position.z);
            Instantiate(tower, safeBlock.transform.position + towerOffset, Quaternion.identity);
            safeBlock.hasTower = true;
        }

    }
}
