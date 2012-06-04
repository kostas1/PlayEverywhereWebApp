function ChatViewModel() {
    var self = this;
    //pewIO;
    self.users = ko.observableArray();
    self.messages = ko.observableArray();
    self.message = ko.observable("");
    self.test = ko.observable('d');

    self.infoMessage = ko.observable("Connecting...");

    self.usersComputed = ko.computed(function () {
        return self.users().join('\n');
    }, self);

    self.messagesComputed = ko.computed(function () {
        return self.messages().join('\n');
    });

    pewIO.onDetails = function () {
        self.infoMessage("Connected.");
        return { username: username, application: application, room: room }; 
    }

    // { username: 'user' }
    pewIO.onJoined = function (user) {
        if (user.username !== username) {
            self.users.push(user.username);
            self.appendMessage(user.username + ' joined.');
        }
    };

    pewIO.onLeft = function (user) {
        self.users.remove(user.username);
        self.appendMessage(user.username + ' left.');
    };

    //pewIO.onInGame = function (total) {
    //    self.appendMessage('In game: ' + total);
    //    self.test('derp');
    //}

    // { username: 'sender', message: msg }
    pewIO.onMessage = function (message) {
        if (typeof (message.message) === "string") {
            self.appendMessage(message.username + ' -> ' + message.message);
        }
    };

    pewIO.onPlayers = function (players) {
        self.users(self.users().concat(players.players));
    };

    self.send = function () {
        if (self.message() !== "") {
            pewIO.sendMessage(self.message());
            self.appendMessage(username + ' -> ' + self.message());
            self.message("");
        }   
    };

    self.appendMessage = function (text) {
        self.messages.push(self.getTimestamp() + ' ' + text);
        var d = document.getElementById('messages');
        d.scrollTop = d.scrollHeight;
    };

    self.getTimestamp = function () {
        var d = new Date();
        return '[' + d.getHours() + ':' + d.getMinutes() + ':' + d.getSeconds() + ']';
    };
    return self;
}
$(function () { ko.applyBindings(new ChatViewModel()) });