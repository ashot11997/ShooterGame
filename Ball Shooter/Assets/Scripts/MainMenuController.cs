using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

	public GameObject MainMenu;
	public GameObject ScoresMenu;
	public GameObject OptionsMenu;

	public AudioSource Auido;

	public Button StartGameBtn;
	public Button ScoresBtn;
	public Button OptionsBtn;
	public Button ExitBtn;


	[Header("Menues")]
	public ScoresMenuController ScoresMenuController;
	public OptionsMenuController OptionsMenuController;

	void Awake()
	{
		StartGameBtn.onClick.AddListener(StartGame);
		ScoresBtn.onClick.AddListener(OpenScoresMenu);
		OptionsBtn.onClick.AddListener(OpenOptionsMenu);
		ExitBtn.onClick.AddListener(Exit);
		OptionsMenuController.Music += MusicToggle;
    }

	void MusicToggle(bool value)
	{
		Auido.enabled = value;
	}

	void Exit()
	{
		Application.Quit();
	}

	void StartGame()
	{
		MainMenu.SetActive(false);
		OptionsMenu.SetActive(false);
		ScoresMenu.SetActive(false);

		SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
	}

	public void Open()
	{
		MainMenu.SetActive(true);
		OptionsMenu.SetActive(false);
		ScoresMenu.SetActive(false);
	}

	void OpenScoresMenu()
	{
		MainMenu.SetActive(false);
		OptionsMenu.SetActive(false);
		ScoresMenu.SetActive(true);
		ScoresMenuController.Setup();
	}

	void OpenOptionsMenu()
	{
		MainMenu.SetActive(false);
		OptionsMenu.SetActive(true);
		ScoresMenu.SetActive(false);
	}
}
