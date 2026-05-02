(function () {
    const header = document.querySelector('.top-shell');
    if (header) {
        const onScroll = function () {
            header.classList.toggle('scrolled', window.scrollY > 10);
        };
        onScroll();
        window.addEventListener('scroll', onScroll, { passive: true });
    }

    document.querySelectorAll('.top-shell').forEach(function (shell) {
        const menuButton = shell.querySelector('.menu-toggle');
        const nav = shell.querySelector('.main-nav');

        if (!menuButton || !nav) {
            return;
        }

        const closeMenu = function () {
            shell.classList.remove('menu-open');
            menuButton.classList.remove('is-open');
            menuButton.setAttribute('aria-expanded', 'false');
        };

        menuButton.addEventListener('click', function () {
            const willOpen = !shell.classList.contains('menu-open');
            shell.classList.toggle('menu-open', willOpen);
            menuButton.classList.toggle('is-open', willOpen);
            menuButton.setAttribute('aria-expanded', String(willOpen));
        });

        nav.querySelectorAll('a').forEach(function (link) {
            link.addEventListener('click', function () {
                if (window.matchMedia('(max-width: 760px)').matches) {
                    closeMenu();
                }
            });
        });

        window.addEventListener('resize', function () {
            if (window.innerWidth > 760) {
                closeMenu();
            }
        });

        document.addEventListener('keydown', function (event) {
            if (event.key === 'Escape') {
                closeMenu();
            }
        });
    });

    const joinForm = document.querySelector('#join-form');
    if (joinForm) {
        const status = joinForm.querySelector('[data-form-status]');
        const messageField = joinForm.querySelector('#message');
        const counter = joinForm.querySelector('[data-char-counter]');

        const updateCounter = function () {
            if (!messageField || !counter) {
                return;
            }
            const length = messageField.value.trim().length;
            counter.textContent = length + ' / 300';
        };

        const setStatus = function (text, isError) {
            if (!status) {
                return;
            }
            status.textContent = text;
            status.classList.toggle('error', Boolean(isError));
            status.classList.toggle('success', !isError && text.length > 0);
        };

        if (messageField) {
            messageField.setAttribute('maxlength', '300');
            messageField.addEventListener('input', updateCounter);
            updateCounter();
        }

        joinForm.addEventListener('submit', function (event) {
            event.preventDefault();
            if (!joinForm.checkValidity()) {
                joinForm.reportValidity();
                setStatus('Please fill in all required fields correctly.', true);
                return;
            }

            setStatus('Application submitted successfully. We will contact you soon.', false);
            joinForm.reset();
            updateCounter();
        });
    }
})();
