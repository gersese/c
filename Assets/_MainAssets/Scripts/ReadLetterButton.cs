using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReadLetterButton : MonoBehaviour {

	void Start () 
	{
		GetComponent<Button>().onClick.AddListener(StartGame);
	}

	void StartGame()
	{
		Application.LoadLevel("LetterScene");
	}
}
