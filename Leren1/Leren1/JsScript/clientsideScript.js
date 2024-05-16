document.getElementById("BtnSections").addEventListener("click", collapsibleSections)

function collapsibleSections() {
    var classStr = document.getElementById("secDiv").getAttribute("class")

    if (classStr.includes("collapse")) {
        document.getElementById("secDiv").setAttribute("class", "navbar flex-column flex-grow w-100 bg-info")
    }
    else {
        document.getElementById("secDiv").setAttribute("class", "navbar collapse flex-column flex-grow w-100 bg-info")
    }
}