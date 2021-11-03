var session = ping.createSession();

session.pingHost(target, function (error, target) {
    if (error)
        console.log(target + ": " + error.toString());
    else
        console.log(target + ": Alive");
});