using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {

	void Start () 
	{
		GetComponent<Button>().onClick.AddListener(StartGame);
	}

	void StartGame()
	{
		Application.LoadLevel("CountdownScene");
	}
}
