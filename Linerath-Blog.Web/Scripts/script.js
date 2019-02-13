function onSearchSubmit() {
    let form = document.getElementById('searchForm');
    let searchElem = document.getElementById('search');

    if (searchElem && form) {
        let uri = form.action;
        let searchText = searchElem.value;

        if (!uri || !searchText || searchText.trim().length <= 0)
            return false;

        if (uri.includes(`${searchElem.name}=`) || uri.includes)
            uri += (uri.includes('?'))
                ? `&${searchElem.name}=${searchText}`
                : `?${searchElem.name}=${searchText}`;

        form.action = uri;

        return true;
    }

    return false;
}

function validateElement(element) {
    let text = $(element).val().trim();

    if (text.length <= 0)
        element.addClass('border-danger');
    else
        element.removeClass('border-danger');

    return text.length > 0;
}
