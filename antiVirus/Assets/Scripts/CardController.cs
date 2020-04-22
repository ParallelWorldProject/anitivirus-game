using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

	BoxCollider2D thisCard;
	public Card card;
	public bool isMouseOver;
	// Use this for initialization
	private void Start () 
	{
		thisCard = gameObject.GetComponent<BoxCollider2D> ();
	}

	private void OnMouseOver()
	{
		isMouseOver = true;
	}
	private void OnMouseExit()
	{
		isMouseOver = false;
	}

}
public enum CardSprite
{
	woman1,
	woman2
}
