using UnityEngine;
using System.Collections;

//public struct Player {
//	
//	public string name = "Player";
//	public string address = "00000000000000000000000000000000";
//
//}
//public struct Unit {
//
//	public int attack = 0;
//	public int defense = 0;
//
//}
//
//public struct Country {
//
//	public int id = "0";
//	public string name = "Country";
//	public Player owner;
//
//}

public class WorldController : MonoBehaviour {

	// player address array
	// qty of players

	public GameObject[] countries;

	public Material freeCountryMaterial;
	public Material ownedCountryMaterial;

	void Start () {

		countries = GameObject.FindGameObjectsWithTag("Country");

		foreach ( GameObject country in countries ) {
			country.GetComponent<Renderer>().material = freeCountryMaterial;
		}
				
	}

	void Update () {
	
	}
}
