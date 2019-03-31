function UpdateF(n)
{
var p = eval(window.document.converter.precision.value);
var mil = window.document.converter.millimeter;
var c = window.document.converter.centimeter;
var d = window.document.converter.decimeter;
var m = window.document.converter.meter;
var k = window.document.converter.kilometer;
var i = window.document.converter.inch;

if ( n == 0) {
	if (mil.value) mil.value = eval(mil.value).toPrecision(p);
	if (c.value) c.value = eval(c.value).toPrecision(p);
    if (d.value) d.value = eval(d.value).toPrecision(p);
    if (m.value) m.value = eval(m.value).toPrecision(p);
    if (k.value) k.value = eval(k.value).toPrecision(p);
};
if ( n == 1 ) {
    c.value = (eval(mil.value) / 10).toPrecision(p);
    d.value = (eval(mil.value) / 100).toPrecision(p);
    m.value = (eval(mil.value) / 1000).toPrecision(p);
    k.value = (eval(mil.value) / 1000000).toPrecision(p);

};
if ( n == 2 ) {
    mil.value = (eval(c.value) * 10).toPrecision(p);
    d.value = (eval(c.value) / 10).toPrecision(p);
    m.value = (eval(c.value) / 100).toPrecision(p);
    k.value = (eval(c.value) / 100000).toPrecision(p);
};
if ( n == 3 ) {
    mil.value = (eval(d.value) * 100).toPrecision(p);
    c.value = (eval(d.value) * 10).toPrecision(p);
    m.value = (eval(d.value) / 10).toPrecision(p);
    k.value = (eval(d.value) / 10000).toPrecision(p);
};
if ( n == 4 ) {
    mil.value = (eval(m.value) * 1000).toPrecision(p);
    c.value = (eval(m.value) * 100).toPrecision(p);
    d.value = (eval(m.value) * 10).toPrecision(p);
    k.value = (eval(m.value) / 1000).toPrecision(p);
};
if ( n == 5 ) {
    mil.value = (eval(k.value) * 1000000).toPrecision(p);
    c.value = (eval(k.value) * 100000).toPrecision(p);
    d.value = (eval(k.value) * 10000).toPrecision(p);
    m.value = (eval(k.value) * 1000).toPrecision(p);
};
}