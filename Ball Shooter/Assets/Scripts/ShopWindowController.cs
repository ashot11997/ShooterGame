using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopWindowController : MonoBehaviour
{

	public GameObject Container;
	public Animator ContainerAnim;
	public GameObject DarkBG;
	public Animator DarkBgAnim;

	public Text MoneyText;

	public Button CloseButton;

	private string FromWhereOpened;

	public WinningController WinningWin;
	public GameOverWinController GameOverWin;

	[Header("Items")]
	public List<WeaponInsideShopController> Items;

	public Action<int> BuyedWeapon;

	public void Setup(int id)
	{
		foreach (var item in Items)
		{
			if (item.Id == id)
			{
				item.Setup();
			}
			
		}
	}

	void Awake()
	{
		CloseButton.onClick.AddListener(Close);
		foreach (var item in Items)
		{
			item.WeaponId += WeaponBuyed;
		}
	}

	void Close() {
		if (FromWhereOpened == "WinningWin")
		{
			Container.SetActive(false);
			WinningWin.Show();
		}
		else if (FromWhereOpened == "GameOverWin")
		{
			Container.SetActive(false);
			GameOverWin.Show();
		}
	}

	public void WeaponBuyed(int id)
	{
		BuyedWeapon.Invoke(id);
	}

	public void Open(string fromWhere)
    {
		FromWhereOpened = fromWhere;
		MoneyText.text = "Your Money: " + PlayerPrefs.GetFloat("Money").ToString();
		Container.SetActive(true);
		ContainerAnim.Play("ScaleIn");
		DarkBG.SetActive(true);
	}
}
