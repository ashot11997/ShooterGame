using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PuseWinController : MonoBehaviour
{
	public GameObject Container;
	public GameObject DarkBG;

	public Button ResumeBtn;
	public Button MenuBtn;

	void Awake()
	{
		ResumeBtn.onClick.AddListener(Resume);
		MenuBtn.onClick.AddListener(OpenMenu);
	}

	void OpenMenu()
	{
		Time.timeScale = 1;
		GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenuController");
		MainMenu.GetComponent<MainMenuController>().Open();
		SceneManager.UnloadScene("GameScene");
	}

	void Resume()
	{
		Close();
		Time.timeScale = 1;
	}

	public void Open()
	{
		Container.SetActive(true);
		DarkBG.SetActive(true);
	}

	public void Close()
	{
		Container.SetActive(false);
		DarkBG.SetActive(false);
	}
}
