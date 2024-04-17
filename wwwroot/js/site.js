const dropdownButton = document.querySelector(".sidebar-dropdown > button");
const dropdownButtonSvg = document.querySelector(".sidebar-dropdown > button > svg");
const dropdownList = document.querySelector(".sidebar-dropdown-list");
const sidebarLinks = document.querySelectorAll(".sidebar-link");

const routeName = window.location.pathname.split("/")[1];

let isOpen = sessionStorage.getItem("isOpen") === null ? "false" : sessionStorage.getItem("isOpen");

window.onload = () => {
    if (sessionStorage.getItem("routeName") === routeName) {
        sidebarLinks.forEach(sidebarLink => {
            if (sidebarLink.getAttribute("data-route-name") === routeName)
                sidebarLink.classList.add("active");
        })
    }

    if (sessionStorage.getItem("isOpen") === "true") {
        dropdownButton.classList.add("open");
        dropdownButtonSvg.classList.add("open");
        dropdownList.classList.add("open");
    }

    if (sessionStorage.getItem("isOpen") === "false") {
        dropdownButton.classList.remove("open");
        dropdownButtonSvg.classList.remove("open");
        dropdownList.classList.remove("open");
    }
};

dropdownButton.addEventListener("click", () => {
    if (isOpen === "false") {
        isOpen = "true"
    } else {
        isOpen = "false"
    }

    sessionStorage.setItem("isOpen", isOpen.toString());

    dropdownButton.classList.toggle("open");
    dropdownButtonSvg.classList.toggle("open");
    dropdownList.classList.toggle("open");
});

sidebarLinks.forEach(sidebarLink => {
    sidebarLink.addEventListener("click", () => {
        const dataRouteName = sidebarLink.getAttribute("data-route-name");
        sessionStorage.setItem("routeName", dataRouteName);
    });
});