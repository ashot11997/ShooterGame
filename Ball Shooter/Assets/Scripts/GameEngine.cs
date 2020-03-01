using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
	public Camera MyCam;

	public Transform EnemyContainer;

	public EnemyController Enemie1;
	public EnemyController Enemie2;
	public EnemyController Enemie3;

	private Vector2 ScreenForms;

	private float Score = 0;

	private Coroutine coroutine1;
	private Coroutine coroutine2;

	public Text ScoreText;
	public Text TimerText;

	public LivesController Lives;
	public DangerAreaController DangerArea;
	public GameOverWinController GameOverWin;
	public WinningController WinningWin;
	public PuseWinController PauseWin;
	public ShopWindowController Shop;
	public PlayerController Player;

	public Button PauseBtn;

	void Awake()
	{
		DangerArea.LivesDestroyed += SetLive;
		DangerArea.GameOver += GameOver;
		PauseBtn.onClick.AddListener(Pause);
		Shop.BuyedWeapon += SetNewWeapon; ;

	}
	
	void SetNewWeapon(int id)
	{
		Player.SetNewWeapon(id);
	}

	void GameOver()
	{
		Debug.Log("Game Over");
		Player.enabled = false;
		StopAllCoroutines();
		foreach (Transform item in EnemyContainer)
		{
			Destroy(item.gameObject);
		}
		GameOverWin.Open(ScoreText.text);
	}

	void Pause()
	{
		Debug.Log("Game Paused");
		PauseWin.Open();
		Time.timeScale = 0;
	}

	void SetLive(float live) {
		Lives.Setup(live);
	}

	void Start()
    {
		//PlayerPrefs.DeleteAll();
		ScreenForms = MyCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MyCam.transform.position.z));
		coroutine1 = StartCoroutine(SpawningEnemie(Enemie1, 2));
		coroutine2 = StartCoroutine(SpawningEnemie(Enemie2, 4.3f));
		StartCoroutine(Timer());

		if (PlayerPrefs.GetInt("WeaponId") == 0 || PlayerPrefs.GetInt("WeaponId") == null || PlayerPrefs.GetInt("WeaponId") == 1)
		{
			SetNewWeapon(1);
			Shop.Setup(1);
		}
		else
		{
			SetNewWeapon(PlayerPrefs.GetInt("WeaponId"));
			Shop.Setup(PlayerPrefs.GetInt("WeaponId"));
		}
		//StartCoroutine(Spawning3Enemie(Enemie3, 5.8f));
	}

	IEnumerator Timer()
	{
		float startTime = 30;
		while (true)
		{
			if (startTime != 0)
			{
				yield return new WaitForSeconds(1);
				startTime--;
				TimerText.text = "00:" + startTime;
			}
			else
			{
				Win();
				break;
			}
		}
	}

	IEnumerator SpawningEnemie(EnemyController enemie, float time) {
		while (true)
		{

			yield return new WaitForSeconds(time);
			Spawn(enemie);
		}
	}

	IEnumerator Spawning3Enemie(EnemyController enemie, float time)
	{
		while (true)
		{

			yield return new WaitForSeconds(time);
			Spawn3(enemie);
		}
	}


	void Spawn(EnemyController enemie)
    {
		EnemyController enemi = Instantiate(enemie, EnemyContainer);
		enemi.transform.position = new Vector3(Random.Range(-ScreenForms.x, ScreenForms.x), ScreenForms.y * -2, 0);
		enemi.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -5f);
		enemi.EnemyDied += EnemyDied;
    }

	void Spawn3(EnemyController enemie)
	{
		EnemyController enemi = Instantiate(enemie, EnemyContainer);
		enemi.transform.position = new Vector3(Random.Range(-ScreenForms.x, ScreenForms.x), ScreenForms.y * -1.8f, 0);
		enemi.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 0f);
		enemi.EnemyDied += EnemyDied;
	}

	void EnemyDied(float score) {
		Score += score * 10;
		ScoreText.text = "Your Score: " + Score;
	}

	private bool IsOneTime = false;
	void Update()
	{
		if (Score > 300 && !IsOneTime)
		{
			StopCoroutine(coroutine1);
			StopCoroutine(coroutine2);
			IsOneTime = true;
			StartCoroutine(Spawning3Enemie(Enemie3, 2f));
		}
	}

	void Win() {
		foreach (Transform item in EnemyContainer)
		{
			Destroy(item.gameObject);
		}
		StopAllCoroutines();
		Debug.Log("Win");
		Player.enabled = false;
		WinningWin.Open(ScoreText.text);
	}
}
