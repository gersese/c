using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour {

	float _timeLeft = 3.5f;
    Text _countdownText;

    void Start()
    {
    	_countdownText = GetComponent<Text>();
    }

    void Update()
    {
        _timeLeft -= Time.deltaTime;
        
        _countdownText.text = Mathf.Round(_timeLeft).ToString();;

        if(_timeLeft < 0)
        {
            Application.LoadLevel("MainScene");
        }
    }
}
