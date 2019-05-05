var connection = new signalR.HubConnectionBuilder()
    .withUrl("/message")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    console.log("connected");
});

connection.on("receiveMessage", (message) => {
    console.log(message);
    gantt.message({ type: "error", text: message, expire: 10000 });
});

function sendMessage() {
    connection.invoke("SendMessage", "super wiadomosc");
}