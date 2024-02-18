mergeInto(LibraryManager.library, {
    SessionToken: function() {
        console.log("in here");
        var returnStr = window.localStorage.getItem("session-token").replace(/"/g, '');
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
});