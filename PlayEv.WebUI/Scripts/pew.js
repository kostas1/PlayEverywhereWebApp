(function () {
	pewIO = {};
	pewIO.connection = io.connect('http://vivid-frost-4598.herokuapp.com/', { port: 80 });
	
	//for debugging
	//pewIO.connection = io.connect('localhost', { port: 5000 });
	
	var log = function (string) {
		var d = new Date();
		var time = d.getHours() + ':' + d.getMinutes() + ':' + d.getSeconds();
		console.log('(' + time + '): ' + string);
	};
	
	// return details for pewIO.io
	// { username: '', application: '', room: '' }
	pewIO.onDetails = function() { log('Details requested'); return { username: '', application: '', room: 'xnull' }; };
	
	// new user joined room
	// { username: 'user' }
	pewIO.onJoined = function(user) { log('Joined: ' + user); };
	
	// user left room
	// { username: 'user' }
	pewIO.onLeft = function(user) { log('Left: ' + user); };
	
	// { username: 'sender', message: msg }
	pewIO.onMessage = function(message) { log('Message: ' + message); };
	
	// game over, he/she won
	// { winner: 'winner' }
	pewIO.onGameOver = function(winner) { log('Game over: ' + winner); };
	
	// show must go on
	pewIO.onContinue = function() { log('Continue'); };
	
	// { total: 5 }
	pewIO.onInGame = function(total) { log('Total: ' + total.total); };
	
	pewIO.onPlayers = function (players) { log('Players: ' + players.players.join()); };

	// send anything to all other people in a room
	pewIO.sendMessage = function(message) {
		pewIO.connection.emit('message', message);
	};
	
	// send info, that given person is winner 
	// { winner: 'winner' }
	pewIO.sendFinishing = function(winner) {
		pewIO.connection.emit('finishing', winner);
	}
	
	pewIO.connection.on('details', function () {
		pewIO.connection.emit('details', pewIO.onDetails());
	});
	
	pewIO.connection.on('joined', function (user) {
		pewIO.onJoined(user);
	});
	
	pewIO.connection.on('left', function (user) {
		pewIO.onLeft(user);
	});
	
	pewIO.connection.on('gameover', function(winner) {
		pewIO.onGameOver(winner);
	});
	
	pewIO.connection.on('continue', function() {
		pewIO.onContinue();
	});
	
	pewIO.connection.on('message', function(msg) {
		pewIO.onMessage(msg);
	});
	
	pewIO.connection.on('ingame', function(total) {
		pewIO.onInGame(total);
    });

	pewIO.connection.on('players', function (players) {
	    pewIO.onPlayers(players);
	});
	
})();