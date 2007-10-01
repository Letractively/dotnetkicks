//
// Right-aligns the contents of the string by padding the field to the left.
// If the contents of the string cannot fit into the field, then the result
// is the entire content of the string.
//
// Example:
//
//      var s = "123";
//      var result1 = s.padLeft("00000");
//      var result2 = s.padLeft("00");
//
// At the end of the above script:
//
//      result1 equals "00123"
//      result2 equals "123"
//

String.prototype.padLeft = function(field)
{
    if (field == null || this.length >= field.length)
        return this.toString();
        
	return (field + this.toString()).slice(-field.length);
}

//
// trimStart, trimEnd and trim remove spaces from the beginning, end or
// both (respectively) ends of the string.
//

String.prototype.trim = function()
{
	return this.replace(/^\s+|\s+$/g, '');
}

String.prototype.trimStart = function()
{
	return this.replace(/^\s+/g, '');
}

String.prototype.trimEnd = function()
{
	return this.replace(/\s+$/g, '');
}
