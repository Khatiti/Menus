
$(function () {

    $("#menuItems").on("change", "input", function () {
        let menu = this;
        if ($(this).is(':checked')) {
            addChildAndSuggestion(menu, $(this).attr("data-name"), $(this).attr("data-address"));
        }
        else {
            removeElements(menu);
        }
    })

})


function insertElement(newNode, parent) {
    parent.appendChild(newNode);
}
function addChildAndSuggestion(x, nn, ads) {
    //add children
    let child = document.createElement('div');
    child.classList.add("chldren", "pl-4", "ml-2");
    insertElement(child, x.parentNode);
    //add suggestion
    let suggestion = document.createElement('div');
    suggestion.classList.add("suggestions", "pl-4", "ml-2");
    insertElement(suggestion, x.parentNode);
    //populate menu list
    getChildMenu(nn, x.parentNode, ads);
}
function removeElements(x) {
    var parent = x.parentNode;
    parent.removeChild(parent.getElementsByClassName("chldren")[0]);
    parent.removeChild(parent.getElementsByClassName("suggestions")[0]);
}
function AppendMenus(parentHtm, data, ads) {
    var object1 = "";
    $.each(data.mainMenus, function (a, b) {
        object1 = object1 + "<div><input type = 'checkbox' data-name='" + b.name + "' data-address='" + ads + "' />  " + b.name + "</div>";
    })
    parentHtm.getElementsByClassName("chldren")[0].innerHTML = object1;
    if (data.relatedMenus != null && data.relatedMenus.length > 0) {
        var object2 = "<p class='my-2'>You might also want:</p><div>";
        $.each(data.relatedMenus, function (a, b) {
            object2 = object2 + "<div><input type = 'checkbox' data-name='" + b.name + "' data-address='" + ads + "' />  " + b.name + "</div>";
        })
        parentHtm.getElementsByClassName("suggestions")[0].innerHTML = object2 + "</div>";
    }
}
function getChildMenu(id, parentHtm, ads) {
    $.get("/api/menuitems",
        { name: id, address: ads },
        function (response) {
            AppendMenus(parentHtm, response, ads);
        }
    );
}