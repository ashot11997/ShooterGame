using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OptionsMenuController : MonoBehaviour
{
	public GameObject MainMenu;

	public Button BackBtn;
	public Button MusicBtn;
	public Text MusicBtnText;
	public Button MoneyBtn;

	public Action<bool> Music;

	private bool IsAudioEnabled = true;

	void Awake()
    {
		BackBtn.onClick.AddListener(Close);
		MusicBtn.onClick.AddListener(MusicToggle);
		MoneyBtn.onClick.AddListener(RemoveItems);
	}

	void Close()
	{
		gameObject.SetActive(false);
		MainMenu.SetActive(true);
	}

	public void MusicToggle()
    {
		if (IsAudioEnabled)
		{
			Music.Invoke(false);
			MusicBtnText.text = "Turn ON Music";
			IsAudioEnabled = false;
		}
		else
		{
			IsAudioEnabled = true;
			Music.Invoke(true);
			MusicBtnText.text = "Turn OFF Music";
		}
	}

	public void RemoveItems()
	{
		PlayerPrefs.SetInt("WeaponId", 0);
	}
}
