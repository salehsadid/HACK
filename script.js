(function () {
    var root = document.documentElement;
    var savedTheme = localStorage.getItem("hack-theme");

    if (savedTheme === "dark" || savedTheme === "light") {
        root.setAttribute("data-theme", savedTheme);
    } else if (window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches) {
        root.setAttribute("data-theme", "dark");
    }

    document.querySelectorAll("[data-theme-toggle]").forEach(function (button) {
        button.addEventListener("click", function () {
            var nextTheme = root.getAttribute("data-theme") === "dark" ? "light" : "dark";
            root.setAttribute("data-theme", nextTheme);
            localStorage.setItem("hack-theme", nextTheme);
        });
    });

    document.querySelectorAll(".site-header").forEach(function (header) {
        var menuButton = header.querySelector(".menu-toggle");
        var nav = header.querySelector(".main-nav");

        if (!menuButton || !nav) {
            return;
        }

        var closeMenu = function () {
            header.classList.remove("menu-open");
            menuButton.setAttribute("aria-expanded", "false");
        };

        menuButton.addEventListener("click", function () {
            var open = !header.classList.contains("menu-open");
            header.classList.toggle("menu-open", open);
            menuButton.setAttribute("aria-expanded", String(open));
        });

        nav.querySelectorAll("a").forEach(function (link) {
            link.addEventListener("click", closeMenu);
        });

        document.addEventListener("keydown", function (event) {
            if (event.key === "Escape") {
                closeMenu();
            }
        });
    });

    var messageField = document.querySelector("#message");
    var counter = document.querySelector("[data-char-counter]");

    if (messageField && counter) {
        var updateCounter = function () {
            var max = messageField.getAttribute("maxlength") || "600";
            counter.textContent = messageField.value.length + " / " + max;
        };

        messageField.addEventListener("input", updateCounter);
        updateCounter();
    }
})();
