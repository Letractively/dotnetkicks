var HTML = {
    a : function(href, child) {
        var e = document.createElement('a');
        e.href = href;
        if (child)
            e.appendChild(typeof(child) === 'string' ? document.createTextNode(child) : child);
        return e;
    },
    img : function(src, alt) {
        var e = document.createElement('img');
        e.src = src;
        if (alt && alt.length > 0) e.alt = alt;
        e.border = '0';
        return e;
    },
    p : function(child) {
        var e = document.createElement('p');
        if (child)
            e.appendChild(typeof(child) === 'string' ? document.createTextNode(child) : child);
        return e;
    },
    span : function(text) {
        var e = document.createElement('span');
        e.appendChild(document.createTextNode(text));
        return e;
    }
};
