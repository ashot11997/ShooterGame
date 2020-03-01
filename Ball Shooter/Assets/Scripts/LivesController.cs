using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
	public List<Image> HearthImages;

	public Color32 EnabledColor;
	public Color32 DisabledColor;

    void Start()
    {
        
    }
	
    void Update()
    {
        
    }

	public void Setup(float live) {
		if (live == 0)
		{
			HearthImages[0].color = DisabledColor;
			HearthImages[1].color = DisabledColor;
			HearthImages[2].color = DisabledColor;
			HearthImages[3].color = DisabledColor;
		}
		else if (live == 25)
		{
			HearthImages[0].color = EnabledColor;
			HearthImages[1].color = DisabledColor;
			HearthImages[2].color = DisabledColor;
			HearthImages[3].color = DisabledColor;
		}
		else if (live == 50)
		{
			HearthImages[0].color = EnabledColor;
			HearthImages[1].color = EnabledColor;
			HearthImages[2].color = DisabledColor;
			HearthImages[3].color = DisabledColor;
		}
		else if (live == 75)
		{
			HearthImages[0].color = EnabledColor;
			HearthImages[1].color = EnabledColor;
			HearthImages[2].color = EnabledColor;
			HearthImages[3].color = DisabledColor;
		}
		else if (live == 100)
		{
			HearthImages[0].color = EnabledColor;
			HearthImages[1].color = EnabledColor;
			HearthImages[2].color = EnabledColor;
			HearthImages[3].color = EnabledColor;
		}
	}
}
