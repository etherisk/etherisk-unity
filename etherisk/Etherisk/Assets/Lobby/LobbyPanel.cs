using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LobbyPanel : MonoBehaviour {

  public GameObject buttonTemplate;

  void PopulateGames(string[] games) {
    var position = new Vector3(0, -10, 0);
    foreach (var game in games) {
      GameObject button = (GameObject) Instantiate(buttonTemplate, position, Quaternion.identity);
      button.transform.SetParent(transform, false);
      button.GetComponentInChildren<Text>().text = game;
      position.y -= 35;
    }
  }
}
