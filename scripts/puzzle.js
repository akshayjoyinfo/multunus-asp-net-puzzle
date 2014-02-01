$(document).ready(function () {
    try {
        var windowWidth = $(window).width();
        var windowHeight = $(window).height();

        var mainCircleX = windowWidth / 2 - 150 ;
        var mainCircleY = windowHeight / 2 - 150;

        var centerX = mainCircleX + 100 ;
        var centerY = mainCircleY + 100;

        // Main Circle Icon
        $(".main-circle").css("left", mainCircleX+13);
        $(".main-circle").css("top", mainCircleY+ 10);

        $("#childcircle1").css("left", centerX);
        $("#childcircle1").css("top", centerY - 220);


        //p1 Point of Circle

        var p1X = centerX + Math.cos(1.72 * Math.PI) * 220;
        var p1Y = centerY + Math.sin(1.71 * Math.PI) * 220


        $("#childcircle2").css("left", p1X);
        $("#childcircle2").css("top", p1Y);


        var p2X = centerX + Math.cos(1.94 * Math.PI) * 220;
        var p2Y = centerY + Math.sin(1.94 * Math.PI) * 220

        $("#childcircle3").css("left", p2X);
        $("#childcircle3").css("top", p2Y);

        var p3X = centerX + Math.cos(0.16 * Math.PI) * 220;
        var p3Y = centerY + Math.sin(0.16 * Math.PI) * 220

        $("#childcircle4").css("left", p3X);
        $("#childcircle4").css("top", p3Y);

        var p4X = centerX + Math.cos(0.38 * Math.PI) * 220;
        var p4Y = centerY + Math.sin(0.38 * Math.PI) * 220

        $("#childcircle5").css("left", p4X);
        $("#childcircle5").css("top", p4Y);

        var p5X = centerX + Math.cos(0.60 * Math.PI) * 220;
        var p5Y = centerY + Math.sin(0.60 * Math.PI) * 220

        $("#childcircle6").css("left", p5X);
        $("#childcircle6").css("top", p5Y);

        var p6X = centerX + Math.cos(0.82 * Math.PI) * 220;
        var p6Y = centerY + Math.sin(0.82 * Math.PI) * 220

        $("#childcircle7").css("left", p6X);
        $("#childcircle7").css("top", p6Y);

        var p7X = centerX + Math.cos(1.04 * Math.PI) * 220;
        var p7Y = centerY + Math.sin(1.04 * Math.PI) * 220

        $("#childcircle8").css("left", p7X);
        $("#childcircle8").css("top", p7Y);

        var p8X = centerX + Math.cos(1.26 * Math.PI) * 220;
        var p8Y = centerY + Math.sin(1.26 * Math.PI) * 220

        $("#childcircle9").css("left", p8X);
        $("#childcircle9").css("top", p8Y);
 
    } catch (err) {
       
    }
});
