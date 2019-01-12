function onSearchSubmit() {
    var elem = document.getElementById("search");
    if (elem) {
        var searchText = elem.value;

        if (searchText && searchText.length > 0)
            return true;
    }

    return false;
}