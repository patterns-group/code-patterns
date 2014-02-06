
RG_START = "<a class='";
RG_ANCHOR = "' id='";
RG_ANCHOR_CLOSE = "'>";
RG_END = "</a>";
RG_ESCRE = /^(&amp;|&lt;|&gt;|&quot;)/;

function max_length(v) {
    var l = 0;
    for (i = 0, s = v.length; i < s; ++i)
        if (v[i].length > l) l = v[i].length;
    return l;
}

RG_ESCMAXSZ = max_length(RG_ESCRE.source.match(new RegExp(RG_ESCRE.source.substr(1), "g"))); // calculating max possible regex match length


function rangecompare(a, b) {
    var depth = Math.min(a.length, b.length);
    for (i = 0; i < depth; ++i) {
        if (a[i] == b[i]) continue;
        return (a[i] < b[i]) ? -1 : 1;
    }
    return b.length - a.length;
};

function applyranges(nodeid, ranges) {
    var codeelem = document.getElementById(nodeid).firstChild;
    // for mozilla, but not through navigator.appName, because chrome navigator properties is totally identical to mozilla
    if (codeelem == null)
        codeelem = document.getElementById(nodeid).nextSibling;

    var code = codeelem.innerHTML;
    var pos = 0;
    var prevpos = 0;
    var line = 1;
    var linepos = 1;
    var rangeidx = 0;
    var currentrange = null;
    var resultcode = '<pre>';

    ranges.sort(rangecompare);

    while (pos < code.length) {
        // testing for exact beginning of the next range
        if (line == ranges[rangeidx][0] && linepos == ranges[rangeidx][1]) {
            if (currentrange == null) {
                currentrange = ranges[rangeidx][4];
                resultcode = resultcode.concat(code.substring(prevpos, pos), RG_START
											, currentrange, RG_ANCHOR, nodeid, '.', currentrange, '.', line, '.', linepos, RG_ANCHOR_CLOSE);
                prevpos = pos;
            }
            else { throw "invalid state" }
        }
        // testing for the end of the range, but taking into account possible wrong range that goes beyound end of line
        else if (line > ranges[rangeidx][2] || line == ranges[rangeidx][2] && linepos >= ranges[rangeidx][3]) {
            if (currentrange != null) {
                resultcode = resultcode.concat(code.substring(prevpos, pos), RG_END);
                prevpos = pos;
                currentrange = null;
                do {
                    do {
                        ++rangeidx;
                    }
                    // skipping duplicates
                    while (rangeidx < ranges.length && rangecompare(ranges[rangeidx], ranges[rangeidx - 1]) == 0);
                }
                // skipping (overlapping) ranges that already passed
                while (rangeidx < ranges.length && (line > ranges[rangeidx][2] || line == ranges[rangeidx][2] && linepos >= ranges[rangeidx][3]));
                if (rangeidx == ranges.length) {
                    break;
                }
                // adjusting (overlapping) ranges that not yet passed,  so they are started at current pos
                if (line > ranges[rangeidx][0] || line == ranges[rangeidx][0] && linepos >= ranges[rangeidx][1]) {
                    ranges[rangeidx][0] = line;
                    ranges[rangeidx][1] = linepos;
                    continue;
                }
            }
            else { throw "invalid state" }
        }
        if (code.charAt(pos) == '\r') { ++pos };
        if (code.charAt(pos++) == '\n') {
            ++line;
            linepos = 1;
        }
        else {
            // shift according to found escape sequence
            var matches = code.substr(pos, RG_ESCMAXSZ).match(RG_ESCRE);
            if (matches != null && matches.length > 0)
                pos += matches[0].length - 1;
            ++linepos;
        }
    }
    codeelem.innerHTML = resultcode.concat(code.substring(prevpos), (currentrange == 0) ? "" : RG_END, "</pre>");
}
