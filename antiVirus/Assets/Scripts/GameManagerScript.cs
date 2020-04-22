using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	//gameobject
	public GameObject cardGameObject;
	public SpriteRenderer cardSpriteRenderer;
	public ResourceManager ResourceManager;
	public CardController mainCardController;

	//variables
	public float fMovingSpeed;
	public float fSideMargin;
	public float fSideTrigger;
	public int dividevalue;
	public Vector2 defaultPositionCard;
	Vector3 pos;
	public float fTranspracy = 0.5f;
	public float fRotation;
	public float fRotationSpeed;
	private bool GameOver;
	private bool RestartGame ;

	//UI
	public TMP_Text Choice;
	float alphaText;
	public Color textColor;
	public SpriteRenderer ChoiceBackground;
	public Color ChoiceColor;
	public TMP_Text CharacterName;
	public TMP_Text Quest;
	public TMP_Text GO;

	//card variables
	private string LeftChoice;
	private string RightChoice;
	private string Questline;
	public Card currentCard;
	public Card testCard;

	//Game Variables
	public static int Economy=50;
	public static int Epidemic=100;
	public static int Politics=50;
	public static int Citizens=50;
	public static int MaxValue = 100;
	public  static int MinValue = 0;
	public static int days = 0;
	//card subtitute logic varibales
	public bool isSubstitute = false;
	public Vector3 cardRotation;//default one
	public Vector3 currentRotation;//current one
	public Vector3 InitialRotation;//initialrotation

	// Use this for initialization
	void Start () {
		CardLoader (testCard);
		GO.text = "";
		//GameOver = false;
		//RestartGame = false;
		
	}

	//for the choice UI
	void UpdateChoice(){
		Choice.color = textColor;
		ChoiceBackground.color = ChoiceColor;
		Quest.text = Questline;
		if (cardGameObject.transform.position.x > 0) {
			
			Choice.text = RightChoice;
		} else {
			Choice.text = LeftChoice;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		textColor.a = Mathf.Min ((Mathf.Abs (cardGameObject.transform.position.x)-fSideMargin)/dividevalue, 1);
		ChoiceColor.a= Mathf.Min ((Mathf.Abs (cardGameObject.transform.position.x)-fSideMargin)/dividevalue,fTranspracy);
		//choosing Logic Handling
		if (cardGameObject.transform.position.x > fSideTrigger) {
			textColor.a = Mathf.Min (Mathf.Abs (cardGameObject.transform.position.x/dividevalue), 1);
			if (Input.GetMouseButtonUp (0)) {
				currentCard.Right ();
				NewCard ();
			}
		} else if (cardGameObject.transform.position.x > fSideMargin) {
			textColor.a = Mathf.Min (Mathf.Abs (cardGameObject.transform.position.x/dividevalue), 1);


		} else if (cardGameObject.transform.position.x > -fSideMargin) {
			textColor.a = 0;

			
		} else if (cardGameObject.transform.position.x > -fSideTrigger) {
			textColor.a = Mathf.Min (Mathf.Abs (cardGameObject.transform.position.x/dividevalue), 1);
		
		} else {
			if (Input.GetMouseButtonUp (0)) {
				currentCard.Left ();
				NewCard ();
			}
		}
		UpdateChoice ();
		//the moving part
		if (Input.GetMouseButton (0) && mainCardController.isMouseOver) {
			Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			cardGameObject.transform.position = pos;
			cardGameObject.transform.eulerAngles = new Vector3(0,0,(-cardGameObject.transform.position.x*fRotation));//rotation
		} else if (!isSubstitute) {
			cardGameObject.transform.position = Vector2.MoveTowards (cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
			cardGameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
		} else if (isSubstitute) {
			cardGameObject.transform.eulerAngles = Vector3.MoveTowards (cardGameObject.transform.eulerAngles, cardRotation, fRotationSpeed);

		}


		if (cardGameObject.transform.eulerAngles == cardRotation) {
			isSubstitute = false;
		}
		//ending the game conditions
		if (!(Economy > MinValue)) {gameOver(1);Debug.Log("gameover");
		} else if (!(Epidemic > MinValue)) {gameOver (2);
		} else if (!(Citizens > MinValue)) {gameOver (3);
		} else if (!(Politics > MinValue)) {gameOver (4);
		}
			

      }

	public void CardLoader(Card card){
		cardSpriteRenderer.sprite = ResourceManager.Sprites [(int)card.Sprite];
		LeftChoice = card.LeftChoice;
		RightChoice = card.RightChoice;
		Questline = card.Quest;
		currentCard = card;
		//reset position
		cardGameObject.transform.position = Vector2.MoveTowards (cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
		cardGameObject.transform.eulerAngles = new Vector3 (0, 0, 0);
		//intitallize
		isSubstitute = true;
		cardGameObject.transform.eulerAngles = InitialRotation;


}
	public void NewCard(){
		int rollDice = Random.Range (0, ResourceManager.Cards.Length );
		CardLoader(ResourceManager.Cards[rollDice]);
			}
	public void Substitute()
	{

	}

	public void gameOver(int ending){
		GameOver = true;
		GO.text = "Game Over"; 
		Debug.Log("gameover");
	}
}