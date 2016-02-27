using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyPanel : MonoBehaviour {

  public GameObject buttonTemplate;

	// Use this for initialization
	void Start () {
    var position = new Vector3(0, -10, 0);
    for (int i = 0; i < 5; ++i) {
	    GameObject button = (GameObject) Instantiate(buttonTemplate, position, Quaternion.identity);
      button.transform.SetParent(transform, false);
      position.y -= 35;
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
