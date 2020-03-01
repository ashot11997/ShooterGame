using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrefab : MonoBehaviour
{

	public Text Name;
	public Text Score;

    public void Setup(string name, float score)
    {
		Name.text = name;
		Score.text = score.ToString();
    }
	
    void Update()
    {
        
    }
}
