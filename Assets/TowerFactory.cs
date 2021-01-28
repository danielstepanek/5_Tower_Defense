using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower tower;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Vector3 towerOffset;
    [SerializeField] GameObject towerStorage;


    Queue<Tower> towerQueue = new Queue<Tower>();
    
    public void AddTower(SafeBlock safeBlock)
    {
        var towers = towerQueue.Count;
        if (towers < towerLimit)
        {
            print("Clicked " + safeBlock.transform.position.x + " " + safeBlock.transform.position.z);
            var newTower = Instantiate(tower, safeBlock.transform.position + towerOffset, Quaternion.identity);
            newTower.transform.parent = towerStorage.transform;
            towerQueue.Enqueue(newTower); 
            newTower.baseSafeblock = safeBlock;
            safeBlock.hasTower = true;
            print(towerQueue.Count);
        }
        else
        {
            Tower oldTower = towerQueue.Dequeue();

            oldTower.baseSafeblock.hasTower = false;
            safeBlock.hasTower = true;
            oldTower.baseSafeblock = safeBlock;

            oldTower.transform.position = safeBlock.transform.position + towerOffset;

            towerQueue.Enqueue(oldTower);

        }
    }
}
