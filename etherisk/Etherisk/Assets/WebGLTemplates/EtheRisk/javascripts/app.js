var riskContract;
var account;
var joinedGameId;

/*
  j Startup()
  e getMyInProgressGames()
  j FetchGameList()
  u ClearGames()
  e getAvailableGames()
    e getNumberOfPlayers()
    u AddGame()...
    e amIMemberOf()
  j CreateGame() OR JoinGame() (OR amIMemberOf() is true)
  u SetJoinedGame()
  (when we have enough players OR see state is IN_PROGRESS)
  j StartGame()
  e startGame()
*/

function getContract() {
  //return Kindarisky.at('d9e3996d5f4aece4d5878a2e2c8d986653e5532e');
  return Kindarisky.deployed();
}

function getAvailableGames() {
  return getContract().getAvailableGames.call();
}

function Startup() {
  web3.eth.getAccounts(function(err, accs) {
    account = accs[0];
    getContract().getMyInProgressGames.call(account).then(function(games) {
      console.log(games);
      for (var i = 0; i < games.length; ++i) {
        if (games[i] != 0) {
          SetJoinedGame(games[i]);
          SendMessage('GameListPanel', 'LoadWorldScene');
          return;
        }
      }
      FetchGameList();
    });
  });
}

function FetchGameList() {
  SendMessage('GameListPanel', 'ClearGames', name);
  // This is called when the Unity app has finished starting up.
  getAvailableGames().then(function(games) {
    console.log("Available games:");
    console.log(games);
    games.forEach(function(gameId) {
      if (gameId != 0) {
        getContract().getNumberOfPlayers.call(gameId).then(function(numPlayers) {
          var name = gameId + " with " + numPlayers + " players";
          console.log(name);
          SendMessage('GameListPanel', 'AddGame', name);
          getContract().amIMemberOf.call(gameId, account).then(function(isMember) {
            console.log('member: ' + isMember);
            if (isMember) {
              SetJoinedGame(gameId);
            }
          })
        });
      }
    });
  });
}

function CreateGame() {
  getContract().createGame(4, 0, {from: account});
  FetchGameList();
}

function JoinGame(name) {
  SetJoinedGame(parseInt(name));
  getContract().join(joinedGameId, 0, {from:account});
  UpdatePlayerCount();
}

function SetJoinedGame(gameId) {
  joinedGameId = gameId;
  SendMessage('GameListPanel', 'SetJoinedGame', '' + joinedGameId);
}

function StartGame() {
  getContract().startGame(joinedGameId, 0, {from:account});
  SendMessage('GameListPanel', 'LoadWorldScene');
}

function UpdatePlayerCount() {
  getContract().getNumberOfPlayers.call(joinedGameId).then(function(numPlayers) {
    var status = numPlayers + " joined out of 4";
    SendMessage('GameListPanel', 'SetStatus', status);

    setTimeout(UpdatePlayerCount, 3000);
  });
}

// WORLD

var nextCountryId = 0;

function WorldStart() {
  setTimeout(UpdateCountry, 1000);
}

function UpdateCountry() {
  getContract().getNumberOfArmies.call(joinedGameId, nextCountryId).then(function(numArmies) {
    var text = nextCountryId + "/Armies: " + numArmies;
    SendMessage("WorldMap", 'SetCountryText', text);
    nextCountryId = (nextCountryId + 1) % 16;
    setTimeout(UpdateCountry, 1000);
  });
}
