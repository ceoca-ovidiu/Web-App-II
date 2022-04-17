const checkCookie = function (username) {
    var user = getCookie("username");
    return user === username
}

function getCookie(name) {
    var cookieArr = document.cookie.split(";")
    for (var i = 0; i < cookieArr.length; i++) {
        var cookiePair = cookieArr[i].split("=");
        if (name === cookiePair[0].trim()) {
            return cookiePair[1];
        }
    }
    return null;
}

const CookieCheck = checkCookie;

export default CookieCheck;