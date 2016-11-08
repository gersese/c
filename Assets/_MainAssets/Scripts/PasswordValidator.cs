using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PasswordValidator : MonoBehaviour {

	const string PASSWORD = "GECL";
	Text _passwordField;

	void Start () 
	{
		//PlayerPrefs.DeleteAll();
		_passwordField = GameObject.FindGameObjectWithTag("Password").GetComponent<Text>(); 
		GetComponent<Button>().onClick.AddListener(ValidatePassword);
	}

	void ValidatePassword()
	{
		if(_passwordField.text.ToUpper() == PASSWORD)
		{
			if(HasCompletedOnce())
				Application.LoadLevel("MenuScene");
			else
				Application.LoadLevel("CountdownScene");
		}
		else
		{
			_passwordField.text = string.Empty;
		}
	}

	bool HasCompletedOnce()
	{
		return PlayerPrefs.GetInt("HasCompleted") == 1;
	}
}
