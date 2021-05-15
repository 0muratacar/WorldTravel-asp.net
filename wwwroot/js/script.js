for (let index = 0; index < models.length; index++) {
    document.getElementById("sect").innerHTML += `
    <div class="mt-3 mx-3 place" id="`+ index + `" style="width: 7%;height:70px;display:inline-block;background-image:url('https://upload.wikimedia.org/wikipedia/commons/c/c9/Flag-map_of_the_world_%281900%29.png');background-size:100% 70px;background-position:top;background-repeat :no-repeat;border-radius:5px;box-shadow: 5px 10px 20px rgb(94, 9, 9) inset;"></div> 

    `;

}
var x = 1
setInterval(function () {
    x += 1;
    
    var index = Math.floor(Math.random() * (models.length + 1));
    var i = Math.floor(Math.random() * (models.length + 1))
    if (index != i) {
        document.getElementById(index).id = i;
        document.getElementById(i).id = index;
    }
    if (!document.getElementsByClassName("place")[index].classList.contains("selected")) {
        if (document.getElementsByClassName("selected").length == 0) {
            // document.getElementsByClassName("mt-3")[index].style.backgroundColor = "rgb(" + Math.random() * 255 + "," + Math.random() * 255 + "," + Math.random() * 255 + ")";

            $("#" + index).css("background-image", "url(" + models[parseInt(index)].flag + ")");
            //  document.getElementsByClassName("mt-3")[index].style.backgroundImage = "url(" + models[parseInt(index)].flag + ")";
            $("#" + index).css("background-size", "100% 70px");
            $("#" + index).css("background-position", "top");
            $("#" + index).css("background-repeat", "no-repeat");
          
            if (!document.getElementsByClassName("place")[i].classList.contains("selected")) {
                $("#" + i).css("background-image", "url(" + models[parseInt(i)].flag + ")");
                //  document.getElementsByClassName("mt-3")[index].style.backgroundImage = "url(" + models[parseInt(index)].flag + ")";
                $("#" + i).css("background-size", "100% 70px");
                $("#" + i).css("background-position", "top");
                $("#" + i).css("background-repeat", "no-repeat");
            }          

        }
  
        if (x % 100 == 0) {
            document.getElementsByClassName("map")[0].style.bottom = "3%";
        }
        else
            document.getElementsByClassName("map")[0].style.bottom = "2%";
    }

}, 10);
for (let index = 0; index < document.getElementsByClassName("place").length; index++) {

    control(index);
}


function control(index) {
    document.getElementsByClassName("place")[index].addEventListener("click", function (e) {
        for (let index = 0; index < document.getElementsByClassName("place").length; index++) {
            if (document.getElementsByClassName("place")[index].classList.contains("selected")) {
                $("#" + index).css("background-image", "url(" + models[parseInt(index)].flag + ")");
                //document.getElementsByClassName("mt-3")[index].style.backgroundColor = "rgb(" + Math.random() * 255 + "," + Math.random() * 255 + "," + Math.random() * 255 + ")";
                //document.getElementsByClassName("mt-3")[index].style.removeProperty("background-image");
            }
            document.getElementsByClassName("place")[index].className = "mt-3 mx-3 place";
            document.getElementsByClassName("place")[index].style.boxShadow = "5px 10px 20px rgb(94, 9, 9) inset";
            document.getElementsByClassName("place")[index].style.borderRadius="5px";
            document.getElementsByClassName("place")[index].style.backgroundImage="url('https://upload.wikimedia.org/wikipedia/commons/c/c9/Flag-map_of_the_world_%281900%29.png')"
        }
      
        playfunct(e);
    });
}

function playfunct(e) {


    for (let index = 0; index < document.getElementsByClassName("video").length; index++) {
        document.getElementsByClassName("video")[index].remove();
        document.getElementsByClassName("name")[index].remove();
        document.getElementsByClassName("close")[index].remove();
        document.getElementsByClassName("radio")[index].remove();
        document.getElementsByClassName("map")[index].remove();

    }
    if (e.target.className != "mt-3 mx-3 place selected") {
        e.target.innerHTML += `<iframe class="radio" width="0" height="0" style="display:none;" src="` + models[parseInt(e.target.id)].radio + `?rel=0&amp;autoplay=1" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
        <i class="fas fa-city fa-3x"></i><h1 class="name">` + models[parseInt(e.target.id)].name + `</h1><span class="close"><i class="fas fa-times fa-3x" style="color:black;"></i></span>` + `<iframe  class="video" width="840" height="473" src="` + models[parseInt(e.target.id)].url + `;rel=0&amp;autoplay=1&mute=1" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
        <iframe src="`+ models[parseInt(e.target.id)].map + `" class="map" style="border:0;" allowfullscreen="" loading="lazy"></iframe> `;
        var opacity = -0.5;
        MyFadeFunction();

        function MyFadeFunction() {
            if (opacity < 1) {
                opacity += .1;
                setTimeout(function () { MyFadeFunction() }, 300);
            }
            document.getElementsByClassName("video")[0].style.opacity = opacity;
            document.getElementsByClassName("name")[0].style.opacity = opacity;
            document.getElementsByClassName("close")[0].style.opacity = opacity;
            document.getElementsByClassName("map")[0].style.opacity = opacity;

        }
        e.target.className = "mt-3 mx-3 place selected";
        e.target.style.boxShadow = "inset 5px 10px 20px white ,20px 20px 50px 15px rgb(255, 236, 162)";
        e.target.style.backgroundImage = "url('" + models[parseInt(e.target.id)].flag + "')";
        e.target.style.backgroundSize = "100% 70px";
        e.target.style.backgroundPosition = "top";
        e.target.style.backgroundRepeat = "no-repeat";
        for (let index = 0; index < document.getElementsByClassName("place").length; index++) {
            if (!document.getElementsByClassName("place")[index].classList.contains("selected")) {
                document.getElementsByClassName("place")[index].style.backgroundImage = "url('https://upload.wikimedia.org/wikipedia/commons/2/22/Earth_Western_Hemisphere_transparent_background.png')";
                document.getElementsByClassName("place")[index].style.boxShadow="none";
               // document.getElementsByClassName("place")[index].style.removeProperty("background-image");

            }
        }
    }

}
