using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DangerAreaController : MonoBehaviour
{
	public Action<float> LivesDestroyed;
	public Action GameOver;

	private float StartLives = 100;

	private bool IsOneTime = false;
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemie")
		{
			if (!IsOneTime)
			{
				if (StartLives != 0)
				{
					StartLives -= 25;
					LivesDestroyed.Invoke(StartLives);
				}
				if (StartLives == 0)
				{
					IsOneTime = true;
					GameOver.Invoke();
				}
			}
			
			EnemyController enemy = coll.GetComponent<EnemyController>();
			enemy.Destroy();
		}
	}
}
