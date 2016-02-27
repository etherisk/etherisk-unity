using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyPanel : MonoBehaviour {

  public GameObject buttonTemplate;
  private Vector3 nextPos = new Vector3(0, -10, 0);

  void AddGame(string gameName) {
    GameObject button = (GameObject) Instantiate(buttonTemplate, nextPos, Quaternion.identity);
    button.transform.SetParent(transform, false);
    button.GetComponentInChildren<Text>().text = gameName;
    nextPos.y -= 35;
  }
}
