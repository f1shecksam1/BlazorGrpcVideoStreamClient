window.showVideoFrame = function (base64Image) {
    var videoCanvas = document.getElementById("videoCanvas");
    var ctx = videoCanvas.getContext("2d");

    var img = new Image();
        img.onload = function() {
        videoCanvas.width = img.width;
        videoCanvas.height = img.height;
        ctx.drawImage(img, 0, 0);
        };
    img.src = "data:image/jpeg;base64," + base64Image;
    };