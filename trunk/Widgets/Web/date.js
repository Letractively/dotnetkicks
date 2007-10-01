//
// Dependencies:
//
//  String.js
//

//
// Returns a lexical representation that is a subset of the lexical
// representations allowed by ISO 8601. This lexical representation is the [ISO
// 8601] extended format CCYY-MM-DDThh:mm:ss where "CC" represents the century,
// "YY" the year, "MM" the month and "DD" the day. The letter "T" is the
// date/time separator and "hh", "mm", "ss" represent hour, minute and second
// respectively. The fractional seconds part is optional and IS NOT SUPPORTED;
// other parts of the lexical form are not optional. Leading zeros are required
// if the year value has fewer than four digits; otherwise they are forbidden.
// The year 0000 is prohibited.
//
// The CCYY field must have at least four digits, the MM, DD, SS, hh, mm and ss
// fields exactly two digits each (not counting fractional seconds); leading
// zeroes must be used if the field would otherwise have too few digits.
//
// This representation is followed by a "Z" to indicate Coordinated Universal
// Time (UTC).
//
// Example:
//
//      1:20 pm on May the 31st, 1999, in UTC, is returned as:
//
//      1999-05-31T13:20:00Z
//
//
// Remarks:
//
// The string returned by this function can be parsed on the .NET Framework 
// using System.Xml.XmlConvert.ToDateTime("...").
//
// WARNING! The fractional seconds part is optional and IS NOT SUPPORTED.
//

Date.prototype.toUTCXMLString = function()
{
	return this.getUTCFullYear().toString().padLeft('0000') + '-' + 
		(this.getUTCMonth() + 1).toString().padLeft('00') + '-' + 
		this.getUTCDate().toString().padLeft('00') + 'T' +
		this.getUTCHours().toString().padLeft('00') + ':' + 
		this.getUTCMinutes().toString().padLeft('00') + ':' +
		this.getUTCSeconds().toString().padLeft('00') + 'Z';
}

//
// Returns a string in the format yyyy-MM-dd'T'HH:mm:ss where "yyyy" represents the year, "MM" the month and "dd" the day. The letter "T" is 
// the date/time separator and "HH", "mm", "ss" represent hour, minute and 
// second respectively. The ISO format is always expressed in Coordinated 
// Universal Time (UTC).
//

Date.prototype.toISOString = function()
{
	return this.getUTCFullYear().toString().padLeft('0000') + '-' +
		(this.getUTCMonth() + 1).toString().padLeft('00') + '-' +
		this.getUTCDate().toString().padLeft('00') + 'T' +
		this.getUTCHours().toString().padLeft('00') + ':' + 
		this.getUTCMinutes().toString().padLeft('00') + ':' +
		this.getUTCSeconds().toString().padLeft('00');
}

// Returns a string in the format yyyy-MM-dd'T'HH:mm:ss where "yyyy" represents the year, "MM" the month and "dd" the day. The letter "T" is 
// the date/time separator and "HH", "mm", "ss" represent hour, minute and 
// second respectively. 
//

Date.prototype.toISO = function()
{
	return this.getFullYear().toString().padLeft('0000') + '-' +
		(this.getMonth() + 1).toString().padLeft('00') + '-' +
		this.getDate().toString().padLeft('00') + 'T' +
		this.getHours().toString().padLeft('00') + ':' + 
		this.getMinutes().toString().padLeft('00') + ':' +
		this.getSeconds().toString().padLeft('00');
}

//
// Parses a string in the format yyyy-MM-dd'T'HH:mm:ss to a Date object, "yyyy" the year, "MM" the month and "dd" the day. 
// The letter "T" is the date/time separator and "HH", "mm", "ss" represent hour, 
// minute and second respectively. The input string is always expected to be in 
// represent a date and time in Coordinated Universal Time (UTC). The returned
// Date object is in local time.
//

ISODate = function(dateString)
{
    if (/^(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})/.test(dateString))
    {
        return new Date(Date.UTC(
            RegExp.$1,      // year
            RegExp.$2 - 1,  // month (Jan = 0, Feb = 1, etc.)
            RegExp.$3,      // date
            RegExp.$4,      // hours
            RegExp.$5,      // minutes
            RegExp.$6));    // seconds
    }
    else
    { 
        return null;
    }
}

// DateAdd javascript implementation on Dates given parameters:
// datepart ('y','M', 'd', 'H', 'm', 's')
// number
//
// using Javascript functions as:
//
// getMilliseconds(), setMilliseconds()
// getSeconds(), setSeconds()
// getMinutes(), setMinutes()
// getHours(), setHours()
// getDate(), setDate()
// getMonth(), setMonth()
// getFullYear(), setFullYear()

Date.prototype.add = function (part, number){
  var temp = this;
  if (!part || number == 0) return temp;
  switch (part){
    case "s":
      temp.setSeconds(temp.getSeconds() + number);
      break;
    case "m":
      temp.setMinutes(temp.getMinutes() + number);
      break;
    case "H":
      temp.setHours(temp.getHours() + number);
      break;
    case "d":
      temp.setDate(temp.getDate() + number);
      break;
    case "M":
      temp.setMonth(temp.getMonth() + number);
      break;
    case "y":
      temp.setFullYear(temp.getFullYear() + number);
      break;
  }
  return temp;
}

// Datetime.Today javascript implementation on Dates

Date.today = function ()
{
    var tempDate = new Date();
    
    tempDate.setMilliseconds(0);
    tempDate.setSeconds(0);
    tempDate.setMinutes(0);
    tempDate.setHours(0);
    
    return tempDate;    
}

// returns the previous Monday within the current week of the given date

Date.previousMondayOf = function(input, treatMondayAsFirstDayOfWeek)
{
    if ( !treatMondayAsFirstDayOfWeek || treatMondayAsFirstDayOfWeek == null )
    {
        treatMondayAsFirstDayOfWeek = false;
    }
    
    if (input == null)
        return null;
                
    if (input.constructor != Date)
        return input;
    
    var day = input.getDay();
    
    if ( treatMondayAsFirstDayOfWeek )
    {
        var delta = ((6 + day) % 7) * -1;
        return input.add('d', delta);
    }
    else
    {
        var delta = (day -1 ) * -1;
        return input.add('d', delta);
    }
}

// returns the next Monday within the current week of the given date

Date.nextMondayOf = function(input)
{
    if (input == null)
        return null;
                
    if (input.constructor != Date)
        return input;
    
    if (input.getDay() == 1)
        return input;
        
    var delta = 7 - (input.getDay() - 1);    
    
    return input.add('d', delta);
}

Date.parseISO = function()
{
    var re = /^(\d{4})-(\d{1,2})-(\d{1,2})T(\d{1,2}):(\d{1,2}):(\d{1,2})(\.\d+)?(Z|(((\+|\-)\d{1,2})\:(\d{1,2})))?/;
    
    return {
    
        //
        // Parses a string in the ISO 8601 format YYYY-MM-DDThh:mm:ss(.s)(TZD)
        // to a Date object, where:
        //
        //     YYYY = four-digit year
        //     MM   = two-digit month (01 = January, etc.)
        //     DD   = two-digit day of month (01 through 31)
        //     hh   = two digits of hour (00 through 23) (am/pm NOT allowed)
        //     mm   = two digits of minute (00 through 59)
        //     ss   = two digits of second (00 through 59)
        //     s    = one or more digits representing a decimal fraction of a second
        //     TZD  = time zone designator (Z or +hh:mm or -hh:mm)
        //
        // Examples:
        //       
        //     1994-11-05T08:15:30-05:00 corresponds to 
        //       November 5, 1994, 8:15:30 am, US Eastern Standard Time.
        //
        //     1994-11-05T13:15:30Z corresponds to the same instant.
        //
        // The returned Date object is in local time. If the input is a Date
        // object then it is returned verbatim.
        //
        // See also: http://www.w3.org/TR/NOTE-datetime
        //
        // *** IMPORTANT! ***
        //
        // The current implementation parses the fractional part of the 
        // second but does not use it. The returned Date object is accurate
        // to the second only.
        //

        parseISO : function(input)
        {
            if (input == null)
                return null;
                
            if (input.constructor === Date)
                return input;
                
            input = input.toString();
                
            var match = re.exec(input);

            if (!match)
                return null; // Invalid format
                
            var year    = parseInt(match[1], 10);
            var month   = parseInt(match[2], 10) - 1; // Jan = 0, etc.
            var date    = parseInt(match[3], 10);
            var hours   = parseInt(match[4], 10);
            var minutes = parseInt(match[5], 10);
            var seconds = parseInt(match[6], 10);
            var milliseconds = 0;

            var tzOffset = match[8];
            
            if (tzOffset.length == 0)
                return new Date(year, month, date, hours, minutes, seconds);

            if (tzOffset !== "Z")
            {
                var offsetHours   = parseInt(match[10], 10);
                var offsetMinutes = parseInt(match[12], 10);
                milliseconds = ((offsetHours * 60) + offsetMinutes) * -60000;
            }
            
            return new Date(Date.UTC(year, month, date, hours, minutes, seconds, milliseconds));
        }
    }
}().parseISO;
