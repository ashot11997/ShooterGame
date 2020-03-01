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
	
    void Update()
    {
		Vector3 vector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, MyCam.nearClipPlane);
		MousePos = MyCam.ScreenToWorldPoint(vector);

		Vector2 look = MousePos - Player.position;
		float rotAngle = Mathf.Atan2(look.y, look.x) * 30f * Mathf.Rad2Deg - 180;

		if (Input.GetButtonDown("Fire1"))
		{
			Player.rotation = rotAngle;

			if (CurrentWeaponId == 1)
			{
				StartCoroutine(Shooting());
			}
			else if (CurrentWeaponId == 2)
			{
				StartCoroutine(Shooting2Bullet());
			}
			else if (CurrentWeaponId == 3)
			{
				StartCoroutine(Shooting3Bullet());
			}
		}
	}

	IEnumerator Shooting() {
		yield return new WaitForSeconds(0.05f);
		var newBullet = Instantiate(Bullet, Fire1StartPoint.position, Fire1StartPoint.rotation);
		Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(Fire1StartPoint.up * Force, ForceMode2D.Impulse);
	}

	IEnumerator Shooting2Bullet()
	{
		yield return new WaitForSeconds(0.05f);
		var newBullet = Instantiate(Bullet, Fire2StartPoint.position, Fire2StartPoint.rotation);
		Rigidbody2D rigidbody = newBullet.GetComponent<Rigidbody2D>();
		rigidbody.AddForce(Fire2StartPoint.up * Force, ForceMode2D.Impulse);

		var newBullet2 = Instantiate(Bullet, Fire3StartPoint.position, Fire3StartPoint.rotation);
		Rigidbody2D rigidbody2 = newBullet2.GetComponent<Rigidbody2D>();
		rigidbody2.AddForce(Fire3StartPoint.up * Force, ForceMode2D.Impulse);
	}

	IEnumerator Shooting3Bullet()
	{
		yield return new WaitForSeconds(0.05f);
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
