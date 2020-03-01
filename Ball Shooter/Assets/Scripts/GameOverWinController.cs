using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWinController : MonoBehaviour
{
	public GameObject Container;
	public Animator ContainerAnim;
	public GameObject DarkBG;
	public Animator DarkBgAnim;

	public Text HighScoreText;
	public Text CurrentScoreText;
	public Text Money;

	public Button RestartBtn;
	public Button SveBtn;
	public Button MenuBtn;
	public Button ShopBtn;

	private float Score = 0;

	private List<float> SList = new List<float>();

	public ShopWindowController Shop;

	void Awake()
	{
		SveBtn.onClick.AddListener(()=> { StartCoroutine(SaveScores()); });
		RestartBtn.onClick.AddListener(Restart);
		ShopBtn.onClick.AddListener(OpenShop);
		MenuBtn.onClick.AddListener(OpenMenu);
	}

	void OpenMenu()
	{
		GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenuController");
		MainMenu.GetComponent<MainMenuController>().Open();
		SceneManager.UnloadScene("GameScene");
	}

	void OpenShop()
	{
		Shop.Open("GameOverWin");
		Container.SetActive(false);
	}
	
	public void Show()
	{
		Container.SetActive(true);
		Container.GetComponent<AudioSource>().enabled = false;
		ContainerAnim.Play("ScaleIn");
	}

	void Restart() {
		SceneManager.UnloadScene("GameScene");
		SceneManager.LoadScene("GameScene",LoadSceneMode.Additive);
	}

	public void Open(string currentScore)
    {
		Container.SetActive(true);
		Container.GetComponent<AudioSource>().enabled = true;
		ContainerAnim.Play("ScaleIn");
		DarkBG.SetActive(true);
		DarkBgAnim.Play("FadeIn");
		Setup(currentScore);
		StartCoroutine(LoadScores());
		SveBtn.enabled = true;
		SveBtn.image.color = SveBtn.colors.normalColor;
	}
	
    public void Setup(string currentScore)
    {
		string[] scores = currentScore.Split(':');
		CurrentScoreText.text = "Your Score:" + scores[1];
		float score = float.Parse(scores[1]);
		Score = score;
		if (score != 0)
		{
			if (PlayerPrefs.GetFloat("Money") == null)
			{
				PlayerPrefs.SetFloat("Money", (score / 10));
				Money.text = "Your Money: " + PlayerPrefs.GetFloat("Money").ToString();
			}
			else
			{
				PlayerPrefs.SetFloat("Money", PlayerPrefs.GetFloat("Money") + (score / 10));
				Money.text = "Your Money: " + PlayerPrefs.GetFloat("Money").ToString();
			}
		}
		else
		{
			if (PlayerPrefs.GetFloat("Money") != null)
			{
				Money.text = "Your Money: " + PlayerPrefs.GetFloat("Money").ToString();
			}
		}
	}

	IEnumerator SaveScores()
	{
		/*string path = Path.Combine(Application.persistentDataPath, "Scores.txt");
		WWW data = new WWW(path);
		yield return data;*/
		
		yield return new WaitForSeconds(0.1f);
		string filePath = Path.Combine(Application.persistentDataPath, "Scores.txt");

		if (File.Exists(filePath))
		{
			File.WriteAllText(filePath, File.ReadAllText(filePath) + " " + Score.ToString());
		}
		else
		{
			File.Create(filePath).Close();
			File.WriteAllText(filePath, Score.ToString());
		}
		SveBtn.enabled = false;
		SveBtn.image.color = SveBtn.colors.disabledColor;
	}

	IEnumerator LoadScores()
	{
		SList.Clear();
		/*string path = Application.streamingAssetsPath + "/" + "Scores.txt";
		WWW data = new WWW(path);
		yield return data;*/


		yield return new WaitForSeconds(0.1f);
		string filePath = Path.Combine(Application.persistentDataPath, "Scores.txt");

		if (File.Exists(filePath))
		{
			string[] ScoreArray = File.ReadAllText(filePath).Split(' ');
			for (int i = 0; i < ScoreArray.Length; i++)
			{
				if (ScoreArray[i] != " ")
				{
					float score = float.Parse(ScoreArray[i]);
					SList.Add(score);
				}
			}

			var max = SList[0];
			for (int i = 1; i < SList.Count; i++)
			{
				if (SList[i] > max)
				{
					max = SList[i];
				}
			}

			if (Score < max)
			{
				HighScoreText.text = "High Score: " + max;
			}
			else
			{
				HighScoreText.text = "High Score: " + Score;
			}
		}
		else
		{
			HighScoreText.text = "High Score: " + Score;
		}

		
	}
		
}
