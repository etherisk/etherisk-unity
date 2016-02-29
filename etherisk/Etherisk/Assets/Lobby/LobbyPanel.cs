using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LobbyPanel : MonoBehaviour {

  public static int joinedGameId;

  public GameObject buttonTemplate;
  public Button createGameButton;
  public Button startGameButton;
  public GameObject gameListPanel;
  public Text statusText;

  private Vector3 nextPos;

  void Start() {
    Application.ExternalCall("Startup");
  }

  void ClearGames() {
    foreach (Transform child in gameListPanel.transform) {
     GameObject.Destroy(child.gameObject);
    }
    nextPos = new Vector3(0, -10, 0);
  }

  void AddGame(string gameName) {
    GameObject button = (GameObject) Instantiate(buttonTemplate, nextPos, Quaternion.identity);
    button.transform.SetParent(gameListPanel.transform, false);
    button.GetComponentInChildren<Text>().text = gameName;
    nextPos.y -= 35;
  }

  void SetStatus(string status) {
    statusText.text = status;
  }

  void SetJoinedGame(string gameIdString) {
    joinedGameId = int.Parse(gameIdString);
    startGameButton.interactable = true;
    createGameButton.interactable = false;
  }

  void LoadWorldScene() {
    SceneManager.LoadScene("World", LoadSceneMode.Single);
  }

  public void RefreshGames() {
    Application.ExternalCall("FetchGameList");
  }

  public void CreateGame() {
    statusText.text = "Creating game";
    Application.ExternalCall("CreateGame");
    createGameButton.interactable = false;
  }

  public void JoinGame(Text text) {
    createGameButton.interactable = false;
    Application.ExternalCall("JoinGame", text.text);
  }

  public void StartGame() {
    Application.ExternalCall("StartGame");
  }
}
