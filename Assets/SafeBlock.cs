using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBlock : MonoBehaviour
{
    public bool hasTower = false;


    void Start()
    {

    }
    private void OnMouseOver()
    {
        if (hasTower == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                FindObjectOfType<TowerFactory>().AddTower(this);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
