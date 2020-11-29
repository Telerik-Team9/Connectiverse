"use strict"
var connection = new signalR.HubConnectionBuilder()
    .withUrl('/ChatTest/Messenger', {
        skipNegotiaiton: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();

connection.on('receiveMessage', addMessageToChat);

connection.on("Test", function (id, data) {
    let spanId = 'likesCount_' + id;

    console.log(data);

    document.getElementById(spanId).innerHTML = `Likes (${data})`;
});

connection.start()
    .catch(error => {
        console.error(error.message);
    });
