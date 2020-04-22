using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Card : ScriptableObject
{
        public CardSprite Sprite;
	    public int CardID;
	    public int DeckID;
		public string CardName;
	    public string Quest;
	    public string LeftChoice;
	    public string RightChoice;
	//下面可以用矩zhen;
	    public int ImpaonEconomyLeft;  
	    public int ImpaonPoliticsLeft;
	    public int ImpaonEpidemicLeft;
	    public int ImpaonCitizensLeft;
	    public int ImpaonEconomyRight;  
	    public int ImpaonPoliticsRight;
	    public int ImpaonEpidemicRight;
	    public int ImpaonCitizensRight;
	//to calculate the chance that a card is likely to appear.not gonna do during Demo. 
	    public int CardWeight;


		//move left choice
		public void Left(){
		//after choice, calculate the impact  on four factors.
		GameManagerScript.Economy += ImpaonEconomyLeft;
		GameManagerScript.Epidemic += ImpaonEpidemicLeft;
		GameManagerScript.Politics += ImpaonPoliticsLeft;
		GameManagerScript.Citizens += ImpaonCitizensLeft;
		//GameManagerScript.days += 1;
		Debug.Log (CardName + "choose left");
		}
		//move right choice
		public void Right(){
		GameManagerScript.Economy += ImpaonEconomyRight;
		GameManagerScript.Epidemic += ImpaonEpidemicRight;
		GameManagerScript.Politics += ImpaonPoliticsRight;
		GameManagerScript.Citizens += ImpaonCitizensRight;
		//GameManagerScript.days += 1;
			Debug.Log (CardName + "choose Right");
		}

}
