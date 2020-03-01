using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag != "DangerArea")
		{

			Destroy(gameObject);
		}
    }
	
    IEnumerator Start()
    {
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
