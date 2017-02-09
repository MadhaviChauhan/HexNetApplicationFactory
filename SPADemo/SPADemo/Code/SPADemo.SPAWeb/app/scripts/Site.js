var divs = ["divArch", "divPrin", "divCond", "divPatterns"];
var links = ["link1", "link2", "link3", "link4"];
var visibleDivId = null;
var activeLink = null;

function toggleVisibility(divId,linkId) {
    if (visibleDivId === divId) {
        visibleDivId = null;
    } else {
        visibleDivId = divId;
    }
    if (activeLink == linkId) {
        activeLink = null;
    }
    else
    {
        activeLink = linkId;
    }
    hideNonVisibleDivs();
    inactiveOtherLinks();
}

function hideNonVisibleDivs() {
    var i, divId, div;

    for (i = 0; i < divs.length; i++) {
        divId = divs[i];
        div = document.getElementById(divId);

        if (visibleDivId === divId) {
            div.style.display = "block";
        } else {
            div.style.display = "none";
        }
    }
}

function inactiveOtherLinks() {
    var i, linkId, link;

    for (i = 0; i < links.length; i++) {
        linkId = links[i];
        link = document.getElementById(linkId);

        if (activeLink === linkId) {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    }
}