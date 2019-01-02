$(document).ready(function() {
    
});

let div_menu = document.getElementById('position');
let img = document.querySelector('.img_icon');
$("#img2").css("display", "none");
div_menu.addEventListener('mouseover',()=>
{
    $("#position").css('width', "230px");
    $("#img1").css("display", "none");
    $("#img2").css("display", "block");
    $(".div_link").css("display", "block");

});
div_menu.addEventListener('mouseout', () => {
    $(".div_link").css("display", "none");
    $("#position").css('width', "70px");
    $("#img2").css("display", "none");
    $("#img1").css("display", "block");

});
$(".sabmit_order").on('click',
    function(parameters) {
        $("#check").css('display', 'none');
    })