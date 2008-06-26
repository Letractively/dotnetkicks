var HTML = {
    a : function(href, child) {
        var e = document.createElement('a');
        if (arguments.length) {
            e.href = href;
            if (child)
                e.appendChild(typeof(child) === 'string' ? this.text(child) : child);
        }
        return e;
    },
    img : function(src, alt) {
        var e = document.createElement('img');
        if (arguments.length) {
            e.src = src;
            if (alt && alt.length > 0) e.alt = alt;
            e.border = '0';
        }
        return e;
    },
    p : function(child) {
        var e = document.createElement('p');
        if (child)
            e.appendChild(typeof(child) === 'string' ? this.text(child) : child);
        return e;
    },
    span : function(text) {
        var e = document.createElement('span');
        if (text) e.appendChild(this.text(text));
        return e;
    },
    text : function(text) {
        return document.createTextNode(text);
    }
};
