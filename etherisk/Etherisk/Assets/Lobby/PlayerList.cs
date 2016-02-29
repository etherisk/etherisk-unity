using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerList : MonoBehaviour {

  public GameObject playerTemplate;
  private Vector3 nextPos = new Vector3(0, -10, 0);

	// Use this for initialization
	void Start () {
    Application.ExternalCall("FetchPlayerList");
	}

  void AddPlayer(string playerName) {
    GameObject player = (GameObject) Instantiate(playerTemplate, nextPos, Quaternion.identity);
    player.transform.SetParent(transform, false);
    player.GetComponentInChildren<Text>().text = playerName;
    nextPos.y -= 35;
  }
}
