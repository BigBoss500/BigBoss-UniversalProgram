function UpdateF(n)
{
var p = eval(window.document.converter.precision.value);
var t = window.document.converter.ton;
var c = window.document.converter.centner;
var k = window.document.converter.kilogram;
var g = window.document.converter.gram;

if ( n == 0) {
	if (mil.value) mil.value = eval(mil.value).toPrecision(p);
	if (c.value) c.value = eval(c.value).toPrecision(p);
    if (d.value) d.value = eval(d.value).toPrecision(p);
    if (m.value) m.value = eval(m.value).toPrecision(p);
};
if ( n == 1 ) {
    c.value = (eval(t.value) * 10).toPrecision(p);
    k.value = (eval(t.value) * 1000).toPrecision(p);
    g.value = (eval(t.value) * 1e+6).toPrecision(p);
};
if ( n == 2 ) {
    k.value = (eval(c.value) * 100).toPrecision(p);
    g.value = (eval(c.value) * 100000).toPrecision(p);
    t.value = (eval(c.value) / 10).toPrecision(p);
};
if ( n == 3 ) {
    t.value = (eval(k.value) / 1000).toPrecision(p);
    c.value = (eval(k.value) / 100).toPrecision(p);
    g.value = (eval(k.value) * 1000).toPrecision(p);
};
if ( n == 4 ) {
    t.value = (eval(g.value) / 1e+6).toPrecision(p);
    c.value = (eval(g.value) / 100000).toPrecision(p);
    k.value = (eval(g.value) / 1000).toPrecision(p);
};
}