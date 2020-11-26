"use strict"
    var connection = new signalR.HubConnectionBuilder()
    .withUrl('/ChatTest/Messenger', { 
    skipNegotiaiton: true,
    transport: signalR.HttpTransportType.WebSockets })
    .build();

    connection.on('receiveMessage', addMessageToChat);

    connection.start()
        .catch(error => {
            console.error(error.message);
        });

    function sendMessageToHub(message) {
        connection.invoke('sendMessage', message);
    }