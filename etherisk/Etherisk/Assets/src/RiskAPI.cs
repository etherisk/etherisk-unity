using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RiskAPI : MonoBehaviour {

	public Text debugText;

	void Start (){

		debugText = GameObject.Find("DebugText").GetComponent<Text>();
		debugText.text = "Hello";

	}

	public void updateData( string content ){
		
		debugText.text += "\n" + content;
		Debug.Log ( content );

	}

	public void updateGames( string[] games ) {

		Debug.Log( games );

	}

	public void updatePlayers( string[] players ) {

	}
		
}
