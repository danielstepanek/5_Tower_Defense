using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    [SerializeField] int damagePerHit = 5;
	public bool gameLost = false;

	[SerializeField] Text healthText;
    void Start()
    {
		healthText.text = health.ToString();
    }
	private void OnTriggerEnter(Collider other)
	{
        if(health > 0)
		{
			int health = this.health - damagePerHit;
			this.health = health;
			healthText.text = health.ToString();
		}

	}
	// Update is called once per frame
	void Update()
    {
		if (health <= 0)
		{
			TriggerLose();
		}
	}
	void TriggerLose()
	{
		if (gameLost == false)
		{
			healthText.color = Color.red;
			healthText.text = "GAME OVER";
			gameLost = true;
		}

	}
}
