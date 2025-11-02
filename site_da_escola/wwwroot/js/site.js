console.log("%csite feito por Gabriel Campos!", "font-size:18px; font-weight:bold; color:#732066;");

console.log("%cInstagram: %chttps://www.instagram.com/biel.camposxz/", "font-weight:bold; color:#ff007f;", "color:#000; font-style:italic;");

console.log("%cGitHub: %chttps://github.com/BielCamposxz", "font-weight:bold; color:#333;", "color:#000; font-style:italic;");

console.log("%cLinkedIn: %chttps://www.linkedin.com/in/gabriel-campos-figueira-72982731a?originalSubdomain=br", "font-weight:bold; color:#0a66c2;", "color:#000; font-style:italic;");

console.log("%cEmail: %cgabrielfigueira88@email.com", "font-weight:bold; color:#ff6600;", "color:#000; font-style:italic;");

    const navbar = document.getElementById('mainNavbar');
    window.addEventListener('scroll', () => {
        if (window.scrollY > 50) {
        navbar.classList.add('scrolled');
        } else {
        navbar.classList.remove('scrolled');
        }
    });


$('.btn-close').click(function () {
    $(".toast-shor").hide();
});
