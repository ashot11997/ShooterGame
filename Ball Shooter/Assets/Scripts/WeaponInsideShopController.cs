using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeaponInsideShopController : MonoBehaviour
{
	public Button BuyBtn;
	public Text ButtonText;

	public float Price;
	public int Id;

	public Action<int> WeaponId;

	

	private void Awake()
	{
		BuyBtn.onClick.AddListener(Buy);
	}

	void Buy() {
		var money = PlayerPrefs.GetFloat("Money");
		if (money > Price)
		{
			ButtonText.text = "Buyed";
			BuyBtn.enabled = false;
			BuyBtn.image.color = BuyBtn.colors.disabledColor;
			money -= Price;
			PlayerPrefs.SetFloat("Money", money);
			PlayerPrefs.SetInt("WeaponId", Id);
			WeaponId.Invoke(Id);
		}
	}

	public void Setup()
	{
		ButtonText.text = "Buyed";
		BuyBtn.enabled = false;
		BuyBtn.image.color = BuyBtn.colors.disabledColor;
	}

}
