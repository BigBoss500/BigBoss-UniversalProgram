function UpdateF(n)
{
var p = eval(window.document.converter.precision.value);
var c = window.document.converter.celsius;
var k = window.document.converter.kelvin;
var f = window.document.converter.fahrengeit;

if ( n == 0) {
	if (c.value) c.value = eval(c.value).toPrecision(p);
	if (k.value) k.value = eval(k.value).toPrecision(p);
	if (f.value) f.value = eval(f.value).toPrecision(p);
};
if ( n == 1 ) {
	k.value = (eval(c.value) + 273.15).toPrecision(p);
	f.value = (1.8 * eval(c.value) + 32).toPrecision(p);

};
if ( n == 2 ) {
	c.value = (eval(k.value) - 273.15).toPrecision(p);
	f.value = (1.8 * (eval(k.value)) - 459.67).toPrecision(p);

};
if ( n == 3 ) {
	c.value = ( (eval(f.value) - 32) / 1.8 ).toPrecision(p);
	k.value = ( (eval(f.value) + 459.67) / 1.8).toPrecision(p);

};
}