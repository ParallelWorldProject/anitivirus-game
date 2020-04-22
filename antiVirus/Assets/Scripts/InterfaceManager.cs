using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
	public GameManagerScript GameManagerScript;
	//value image
	public Image Economy;
	public Image Epidemic;
	public Image Politics;
	public Image Citizens;
	//value imapct later
	public Image EcoImp;
	public Image EpiImp;
	public Image PolImp;
	public Image CitImp;
    // Update is called once per frame
    void Update()
    {
        //value image change
		Economy.fillAmount = (float)GameManagerScript.Economy/GameManagerScript.MaxValue;
		Epidemic.fillAmount = (float)GameManagerScript.Epidemic/GameManagerScript.MaxValue;
		Citizens.fillAmount = (float)GameManagerScript.Citizens/GameManagerScript.MaxValue;
		Politics.fillAmount = (float)GameManagerScript.Politics/GameManagerScript.MaxValue;

		Debug.Log ("Economy is" + Economy.fillAmount);
		Debug.Log ("Epid is" + Epidemic.fillAmount);
		Debug.Log ("Citizens is " + Citizens.fillAmount);
		Debug.Log ("Politics is " + Politics.fillAmount);
		//for showing the influence part later
		//if (){}
		//else if(){}
		//else{}

    }
}
