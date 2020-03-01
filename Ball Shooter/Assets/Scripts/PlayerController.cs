using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Player Part")]
	public Rigidbody2D Player;
	public Camera MyCam;

	private Vector2 MousePos;

	public Sprite Weapon1;
	public Sprite Weapon2;
	public Sprite Weapon3;

	public SpriteRenderer Renderer;


	//-----------------------

	[Header("Shooting Part")]
	public Transform Fire1StartPoint;
	public Transform Fire2StartPoint;
	public Transform Fire3StartPoint;
	public Transform Fire4StartPoint;
	public GameObject Bullet;

	public float Force = 20f;

	private int CurrentWeaponId;

	void FixedUpdate()
    {
		Vector2 look = MousePos - Player.position;
		float rotAngle = Mathf.Atan2(look.y,look.x) * 30f * Mathf.Rad2Deg - 180;
		Player.rotation = rotAngle;
    }
	
    void Update()
    {
		Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, MyCam.nearClipPlane);
		MousePos = MyCam.ScreenToWorldPoint(vector);

		if (Input.GetButtonDown("Fire1"))
		{
			if (CurrentWeaponId == 1)
			{
				Shooting();
			}
			else if (CurrentWeaponId == 2)
			{
				Shooting2Bullet();
			}
			else if (CurrentWeaponId == 3)
			{
				Shooting3Bullet();
			}
		}
	}

	void Shooting() {
		var newBullet = Instantiate(Bullet, Fire1StartPoint.position, Fire1StartPoint.rotation);
		Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(Fire1StartPoint.up * Force, ForceMode2D.Impulse);
	}

	void Shooting2Bullet()
	{
		var newBullet = Instantiate(Bullet, Fire2StartPoint.position, Fire2StartPoint.rotation);
		Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(Fire2StartPoint.up * Force, ForceMode2D.Impulse);

		var newBullet2 = Instantiate(Bullet, Fire3StartPoint.position, Fire3StartPoint.rotation);
		Rigidbody2D rigidbody2 = newBullet2.GetComponent<Rigidbody2D>();
		rigidbody2.AddForce(Fire3StartPoint.up * Force, ForceMode2D.Impulse);
	}

	void Shooting3Bullet()
	{
		var newBullet = Instantiate(Bullet, Fire2StartPoint.position, Fire2StartPoint.rotation);
		Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(Fire2StartPoint.up * Force, ForceMode2D.Impulse);

		var newBullet2 = Instantiate(Bullet, Fire3StartPoint.position, Fire3StartPoint.rotation);
		Rigidbody2D rigidbody2 = newBullet2.GetComponent<Rigidbody2D>();
		rigidbody2.AddForce(Fire3StartPoint.up * Force, ForceMode2D.Impulse);

		var newBullet3 = Instantiate(Bullet, Fire4StartPoint.position, Fire4StartPoint.rotation);
		Rigidbody2D rigidbody3 = newBullet3.GetComponent<Rigidbody2D>();
		rigidbody3.AddForce(Fire4StartPoint.up * Force, ForceMode2D.Impulse);
	}

	public void SetNewWeapon(int id)
	{
		CurrentWeaponId = id;
		if (id == 1)
		{
			Renderer.sprite = Weapon1;
		}
		else if (id == 2)
		{
			Renderer.sprite = Weapon2;
		}
		else if (id == 3)
		{
			Renderer.sprite = Weapon3;
		}
	}
}
