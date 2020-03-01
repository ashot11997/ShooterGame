using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoresMenuController : MonoBehaviour
{
	public GameObject MainMenu;

	public Transform Content;
	public ScorePrefab Prefab;

	public Button BackBtn;

	private List<float> SList = new List<float>();

	void Awake()
	{
		BackBtn.onClick.AddListener(Close);
	}

	void Close()
	{
		gameObject.SetActive(false);
		MainMenu.SetActive(true);
	}

	public void Setup()
	{
		foreach (Transform item in Content)
		{
			Destroy(item.gameObject);
		}
		SList.Clear();

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

			foreach (var item in SList)
			{
				var newScore = Instantiate(Prefab, Content);
				newScore.Setup("Ashot", item);
			}
		}
		else
		{
			//chka achok
		}
	}
}
