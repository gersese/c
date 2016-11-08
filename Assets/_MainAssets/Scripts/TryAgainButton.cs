using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TryAgainButton : MonoBehaviour 
{

	void Start () 
	{
		GetComponent<Image>().enabled = false;
		GetComponent<Button>().enabled = false;
		transform.GetChild(0).GetComponent<Text>().enabled = false;
		
		GetComponent<Button>().onClick.AddListener(TryAgain);
	}

	void TryAgain()
	{
		Application.LoadLevel("CountdownScene");
	}

	public void Show()
	{
		GetComponent<Image>().enabled = true;
		GetComponent<Button>().enabled = true;
		transform.GetChild(0).GetComponent<Text>().enabled = true;
	}
}
