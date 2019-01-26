function onSearchSubmit() {
    var elem = document.getElementById("search");
    if (elem) {
        let searchText = elem.value;

        if (searchText && searchText.length > 0)
            return true;
    }

    return false;
}