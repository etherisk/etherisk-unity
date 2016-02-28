var riskContract;

function getContract() {
  return Kindarisky.at('d9e3996d5f4aece4d5878a2e2c8d986653e5532e');
}

function getAvailableGames() {
  return riskContract.getAvailableGames.call();
}

window.onload = function() {
  web3.eth.getAccounts(function(err, accs) {
    riskContract = getContract();
    getAvailableGames().then(function(games) {
      games.forEach(function(game) {
        if (game != -1) {
          var name = "Game " + game;
          SendMessage('GameList', 'AddGame', name);
        }
      });
    });
  });
}
