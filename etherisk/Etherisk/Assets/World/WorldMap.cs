using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class WorldMap : MonoBehaviour {

  public GameObject countryPrefab;
  public Color[] colors;

  private Button[,] countries;

	// Use this for initialization
	void Start () {
    float half = 1.5f;
    countries = new Button[4, 4];
	  for (int y = 0; y < 4; ++y) {
      for (int x = 0; x < 4; ++x) {
        var obj = (GameObject) Instantiate(countryPrefab, new Vector3((x - half) * 100, (y - half) * 100, 0), Quaternion.identity);
        countries[x, y] = obj.GetComponent<Button>();
        countries[x, y].transform.SetParent(transform, false);
        countries[x, y].image.color = colors[x];
      }
    }

    Application.ExternalCall("WorldStart");
	}

  void SetCountryText(string encoded) {
    string[] split = encoded.Split('/');
    string countryS = split[0];
    string text = split[1];
    int countryId = int.Parse(countryS);
    int x = countryId % 4;
    int y = countryId / 4;
    countries[x, y].GetComponentInChildren<Text>().text = text;
  }	
}
