/*class Message {
    constructor(username, text, when) {
        this.userName = username;
        this.text = text;
        this.when = when;
    }
}*/

// userName is declared in razor page.
/*const username = userName;
const userprofilepictureurl = userProfilePictureUrl;*/
//const textInput = document.getElementById('messageText');
//const whenInput = document.getElementById('when');
const chat = document.getElementById('chat');
//const messagesQueue = [];

function addMessageToChat(message, username, userprofilepictureurl) {

    // Main container
    let container = document.createElement('div');
    container.className = "d-flex justify-content-start mb-4";

    // Img container
    let imgcontainer = document.createElement('div');
    imgcontainer.className = "img_cont_msg";

    let senderpicture = document.createElement('img');
    senderpicture.className = "rounded-circle user_img_msg";
    senderpicture.src = userprofilepictureurl;

    imgcontainer.appendChild(senderpicture);

    // Msg container
    let msgcontainer = document.createElement('div');
    msgcontainer.className = "msg_cotainer";
    msgcontainer.innerHTML = message;

    //let sender = document.createElement('p');
    //sender.className = "sender";
    //sender.innerHTML = username;

    let when = document.createElement('span');
    when.className = "msg_time";
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    //msgcontainer.appendChild(sender);
    msgcontainer.appendChild(when);

    container.appendChild(imgcontainer);
    container.appendChild(msgcontainer);
    chat.appendChild(container);
    chat.scrollTop = chat.scrollHeight;

    document.getElementById('messageSend').value = '';
}



/*function addMessageToChat(message) {

    let isCurrentUserMessage = true;
    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = username;

    let senderpicture = document.createElement('p');
    senderpicture.className = "";
    senderpicture.innerHTML = userprofilepictureurl;

    let text = document.createElement('p');
    text.innerHTML = message;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    container.appendChild(sender);
    container.appendChild(senderpicture);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
}*/


/*function addMessageToChat(message) {

    let isCurrentUserMessage = true;
    let container = document.createElement('div');
    container.className = isCurrentUserMessage ? "container darker" : "container";

    let sender = document.createElement('p');
    sender.className = "sender";
    sender.innerHTML = "Ali";
    let text = document.createElement('p');
    text.innerHTML = message;

    let when = document.createElement('span');
    when.className = isCurrentUserMessage ? "time-left" : "time-right";
    var currentdate = new Date();
    when.innerHTML =
        (currentdate.getMonth() + 1) + "/"
        + currentdate.getDate() + "/"
        + currentdate.getFullYear() + " "
        + currentdate.toLocaleString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true })

    container.appendChild(sender);
    container.appendChild(text);
    container.appendChild(when);
    chat.appendChild(container);
}*/
