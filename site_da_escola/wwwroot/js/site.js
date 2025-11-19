console.log("%csite feito por Gabriel Campos!", "font-size:18px; font-weight:bold; color:#732066;");

console.log("%cInstagram: %chttps://www.instagram.com/biel.camposxz/", "font-weight:bold; color:#ff007f;", "color:#000; font-style:italic;");

console.log("%cGitHub: %chttps://github.com/BielCamposxz", "font-weight:bold; color:#333;", "color:#000; font-style:italic;");

console.log("%cLinkedIn: %chttps://www.linkedin.com/in/gabriel-campos-figueira-72982731a?originalSubdomain=br", "font-weight:bold; color:#0a66c2;", "color:#000; font-style:italic;");

console.log("%cEmail: %cgabrielfigueira88@email.com", "font-weight:bold; color:#ff6600;", "color:#000; font-style:italic;");

   

document.addEventListener("DOMContentLoaded", () => {
    const stars = document.querySelectorAll(".stars i");
    const inputNota = document.getElementById("notaSelecionada");

    stars.forEach(star => {
        star.addEventListener("click", () => {
            const value = star.getAttribute("data-value");
            inputNota.value = value; 

            stars.forEach(s => {
                if (parseInt(s.getAttribute("data-value")) <= value) {
                    s.classList.add("text-warning");
                    s.classList.remove("bi-star");
                    s.classList.add("bi-star-fill");
                } else {
                    s.classList.remove("text-warning");
                    s.classList.remove("bi-star-fill");
                    s.classList.add("bi-star");
                }
            });
        });
    });
});



$('.btn-close').click(function () {
    $(".toast-shor").hide();
});
