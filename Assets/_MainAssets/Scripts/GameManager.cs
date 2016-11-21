using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject _gerald;
	GameObject _clariz;
	ClarizRaycaster _clarizRaycaster;
	ClarizHealth _clarizHealth;
	CharacterAnimation _geraldAnimation;
	CharacterAnimation _clarizAnimation;
	BackgroundManager _backgroundManager;
	SpriteManager _spriteManager;
	GeraldMovement _geraldMovement;
	SpawnManager _spawnManager;
	TryAgainButton _tryAgainButton;
	CharacterControl _characterControl;
	GameObject _loadingGiftText;

	[SerializeField]
	GameObject[] _clarizSprites;

	[SerializeField]
	GameObject[] _geraldSprites;

	float _distance = 0.0f;

	void Start () 
	{
		_backgroundManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<BackgroundManager>();
		_spriteManager = GetComponent<SpriteManager>();
		_clariz = GameObject.FindGameObjectWithTag("Clariz");
		_gerald = GameObject.FindGameObjectWithTag("Gerald");

		_clarizRaycaster = _clariz.GetComponent<ClarizRaycaster>();
		_clarizHealth = _clariz.GetComponent<ClarizHealth>();
		_clarizAnimation = _clariz.GetComponent<CharacterAnimation>();
		_characterControl = _clariz.GetComponent<CharacterControl>();
		_geraldAnimation = _gerald.GetComponent<CharacterAnimation>();
		_geraldMovement = _gerald.GetComponent<GeraldMovement>();
		_spawnManager = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnManager>();
		_tryAgainButton = GameObject.FindGameObjectWithTag("TryAgainButton").GetComponent<TryAgainButton>();
		_loadingGiftText = GameObject.FindGameObjectWithTag("LoadingGiftText");
	}
	
	void Update () 
	{
		if(_clarizHealth.GetRemainingHits() == 2)
		{
			_spriteManager.ChangeSprite(_clariz.transform, _clarizSprites[1]);
		}
		else if(_clarizHealth.GetRemainingHits() == 1)
		{
			_spriteManager.ChangeSprite(_clariz.transform, _clarizSprites[2]);
		}
		else if(_clarizHealth.GetRemainingHits() == 0)
		{
			_spriteManager.ChangeSprite(_clariz.transform, _clarizSprites[3]);
			_spriteManager.ChangeSprite(_gerald.transform, _geraldSprites[0]);
			_backgroundManager.StopScrolling();
			_geraldAnimation.StopAnimation();
			_geraldMovement.StopMovement();
			_spawnManager.StopSpawning();
			StopObstacles();
			_characterControl.DisableControl();
			_clarizAnimation.StopAnimation();
			_geraldAnimation.StopAnimation();

			if(PlayerPrefs.GetInt("HasCompleted") == 1)
			{
				StartCoroutine(LoadMenuScene());
			}
			else
			{
				StartCoroutine(LoadCountdownScene());
				SetAsCompleted();
			}
		}

		if(_clarizRaycaster.HasReachedGerald())
		{
			_backgroundManager.StopScrolling();
			_geraldAnimation.StopAnimation();
			_geraldMovement.StopMovement();
			_spawnManager.StopSpawning();
			StopObstacles();
			_distance = 0;
			_loadingGiftText.GetComponent<Text>().enabled = true;
			_characterControl.DisableControl();
			_geraldAnimation.StopAnimation();
			_clarizAnimation.StopAnimation();
			
			if(PlayerPrefs.GetInt("HasCompleted") == 1)
			{
				StartCoroutine(LoadMenuScene());
			}
			else
			{
				StartCoroutine(LoadLetterScene());
				SetAsCompleted();
			}

		}

		UpdateDistance();
		UpdateGeraldSprite();
	}

	void UpdateDistance()
	{
		_distance = Mathf.Abs(_clariz.transform.localPosition.x) + _gerald.transform.localPosition.x;
	}

	void UpdateGeraldSprite()
	{
		if(Mathf.Round(_distance) == 500)
			_spriteManager.ChangeSprite(_gerald.transform, _geraldSprites[1]);
		else if(Mathf.Round(_distance) == 400)
			_spriteManager.ChangeSprite(_gerald.transform, _geraldSprites[2]);
		else if(Mathf.Round(_distance) == 300)
			_spriteManager.ChangeSprite(_gerald.transform, _geraldSprites[3]);
		else if(Mathf.Round(_distance) == 200)
			_spriteManager.ChangeSprite(_gerald.transform, _geraldSprites[4]);
	}

	void StopObstacles()
	{
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

		for(int i = 0; i < obstacles.Length; i++)
		{
			obstacles[i].GetComponent<PolygonCollider2D>().enabled = false;
		}
	}

	IEnumerator LoadLetterScene()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("LetterScene");
	}

	IEnumerator LoadMenuScene()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("MenuScene");
	}

	IEnumerator LoadCountdownScene()
	{
		yield return new WaitForSeconds(3);
		Application.LoadLevel("CountdownScene");
	}

	void SetAsCompleted()
	{
		PlayerPrefs.SetInt("HasCompleted", 1);
	}
}
