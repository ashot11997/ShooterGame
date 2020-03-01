using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyController : MonoBehaviour
{
	public Canvas MyCanvas;
	public Text LifeText;
	public Rigidbody2D Rigidbody;

	private float FirstScore;
	private float Score;
	private Vector2 ScreenForms;

	public Action<float> EnemyDied;

	public GameObject Explotion;

	public AudioSource Audio;

    void Start()
    {
		Audio.enabled = false;
		MyCanvas.worldCamera = Camera.main;
		FirstScore = float.Parse(LifeText.text);
		Score = FirstScore;
		//Rigidbody.velocity = new Vector2(4f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Bullet")
		{

			Score--;
			LifeText.text = Score.ToString();
		}
	}

	private bool isOneTime = false;
	void Update()
	{
		if (Score <= 0 && !isOneTime)
		{
			isOneTime = true;
			EnemyDied.Invoke(FirstScore);
			Destroy();
		}
	}

	public void Destroy()
	{
		LifeText.gameObject.SetActive(false);
		Audio.enabled = true;
		Explotion.SetActive(true);
		Destroy(gameObject, 0.4f);
	}
}
