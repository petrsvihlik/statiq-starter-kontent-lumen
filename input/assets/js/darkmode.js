/** Dark Mode */
function ready(fn) {
    if (document.readyState === "complete" || (document.readyState !== "loading" && !document.documentElement.doScroll)) {
        fn();
    } else if (document.addEventListener) {
        document.addEventListener('DOMContentLoaded', fn);
    } else {
        document.attachEvent('onreadystatechange', function () {
            if (document.readyState != 'loading')
                fn();
        });
    }
}

window.ready(function () {
    var body = document.getElementsByTagName("BODY")[0];
    var darkMode = window.localStorage.getItem('darkMode');
    if (darkMode === 'true' || (darkMode === null && window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches)) {
        body.classList.add("dark");
        document.getElementById('DarkModeSwitcher').checked = true;
        window.localStorage.setItem('darkMode', true);
    }

    window.setDarkMode = function (on) {
        if (on) {
            body.classList.add("dark");
        }
        else {
            body.classList.remove("dark");
        }
        window.localStorage.setItem('darkMode', on);
    }

    window.toggleDarkMode = function () {
        var darkMode = window.localStorage.getItem('darkMode') === 'true';
        setDarkMode(!darkMode);
    };

    window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', e => {
        setDarkMode(e.matches);
    });
});

/** End Dark Mode */