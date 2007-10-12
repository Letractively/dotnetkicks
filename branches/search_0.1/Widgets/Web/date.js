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
