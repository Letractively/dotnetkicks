/*------------------------------------------------------------------------------
Function:       jsTrace()
Author:         Aaron Gustafson (aaron at easy-designs dot net)
Creation Date:  1 November 2005
Version:        1.3
Homepage:       http://www.easy-designs.net/code/jsTrace/
License:        Creative Commons Attribution-ShareAlike 2.0 License
                http://creativecommons.org/licenses/by-sa/2.0/
Note:           If you change or improve on this script, please let us know by 
                emailing the author (above) with a link to your demo page.
Enhancements:   Cookies - Joe Shelby (http://www.io.com/~acroyear/)
------------------------------------------------------------------------------*/
var jsTrace = {
  
  /*----------------------------------------------------------------------------
                                Core Functionality
  ----------------------------------------------------------------------------*/
  // vars
  debugging_on: false,
  window:       null,
  viewport:     null,
  buffer:       '',
  // initialization
  init: function(){
    if( !document.getElementsByTagName ||
        !document.getElementById ||
        !document.createElement ||
        !document.createTextNode ) return;
    jsTrace.createWindow();
    jsTrace.getCookie();
    jsTrace.debugging_on = true;
  },
  // jsTrace window creation
  createWindow: function(){
    jsTrace.window = document.createElement( 'div' );     // the window
    jsTrace.window.style.background = '#000';
    jsTrace.window.style.font       = '80% "Lucida Grande", "Lucida Sans Unicode", sans-serif';
    jsTrace.window.style.padding    = '2px';
    jsTrace.window.style.position   = 'absolute';
    jsTrace.window.style.top        = '50px';
    jsTrace.window.style.left       = '700px';
    jsTrace.window.style.height     = '360px';
    jsTrace.window.style.zIndex     = '100';
    jsTrace.window.style.minHeight  = '150px';
    jsTrace.window.style.width      = '190px';
    jsTrace.window.style.minWidth   = '150px';
    var x = document.createElement('span');             // the closer
        x.style.border     = '1px solid #000';
        x.style.cursor     = 'pointer';
        x.style.color      = '#000';
        x.style.display    = 'block';
        x.style.lineHeight = '.5em';
        x.style.padding    = '0 0 3px';
        x.style.position   = 'absolute';
        x.style.top        = '4px';
        x.style.right      = '4px';
        x.setAttribute( 'title', 'Close jsTrace Debugger' );
        x.appendChild( document.createTextNode( 'x' ) );
        jsTrace.addEvent( x, 'click', function(){ jsTrace.killWindow(); } );
        jsTrace.window.appendChild( x );
    var sh = document.createElement('div');             // the stretcher holder
        sh.style.position = 'absolute';
        sh.style.bottom   = '3px';
        sh.style.right    = '3px';
    var sg = document.createElement('span');            // the stretcher grip
        sg.style.border   = '5px solid #ccc';
        sg.style.borderLeftColor = sg.style.borderTopColor = '#000';
        sg.style.cursor   = 'pointer';
        sg.style.color    = '#ccc';
        sg.style.display  = 'block';
        sg.style.height   = '0';
        sg.style.width    = '0';
        sg.style.overflow = 'hidden';
        sg.setAttribute( 'title', 'Resize the jsTrace Debugger' );
        if( typeof( Drag ) != 'undefined' ){ // make it draggable
          sg.xFrom = 0;
          sg.yFrom = 0;
          Drag.init( sg, null, null, null, null, null, true, true );
          sg.onDrag = function( x, y ){
                        jsTrace.resizeX( x, this );
                        jsTrace.resizeY( y, this );
                        jsTrace.adjustViewport();
                      };
          sg.onDragEnd = function(){
                       jsTrace.setCookie();
                     };
          sh.appendChild( sg );
          jsTrace.window.appendChild( sh );
        }
    var tools = document.createElement( 'div' );        // additional tools holder
        tools.style.fontSize      = '12px';
        tools.style.textTransform = 'uppercase';
        tools.style.lineHeight    = '18px';
        tools.style.position      = 'absolute';
        tools.style.bottom        = '5px';
        tools.style.left          = '4px';
    var the_tools = new Array();
        // define any Add-on tools
        the_tools.push( [ 'delimit',                                  // <- display text
                          'Add a Delimeter',                          // <- tooltip
                          function(){ jsTrace.sendDelimeter(); } ] ); // <- onclick
        the_tools.push( [ 'clear',
                          'Clear the Window',
                          function(){ jsTrace.clearWindow(); } ] );
    var tools_count = the_tools.length;
    var i, the_tool;
    for( var i=0; i < tools_count; i++ ){
      the_tool = document.createElement( 'span' );
      the_tool.style.background  = '#ccc';
      the_tool.style.color       = '#000';
      the_tool.style.margin      = '0 2px 0 0';
      the_tool.style.padding     = '0 5px';
      the_tool.style.cursor      = 'pointer';
      the_tool.appendChild( document.createTextNode( the_tools[i][0] ) );
      the_tool.setAttribute( 'title', the_tools[i][1] );
      jsTrace.addEvent( the_tool, 'click', the_tools[i][2] );
      tools.appendChild( the_tool );
    }
    jsTrace.window.appendChild( tools );
    var header = document.createElement( 'h3' );
        header.style.background  = '#ccc';
        header.style.color       = '#000';
        header.style.cursor      = 'pointer';
        header.style.fontSize    = '1em';
        header.style.fontVariant = 'small-caps';
        header.style.margin      = '0 0 2px';
        header.style.padding     = '5px 10px';
        header.style.lineHeight      = '15px';
        header.appendChild( document.createTextNode( 'jsTrace Debugger' ) );
        jsTrace.window.appendChild( header );
    jsTrace.viewport = document.createElement( 'pre' );
    jsTrace.viewport.style.border   = '1px solid #ccc';
    jsTrace.viewport.style.color    = '#ebebeb';
    jsTrace.viewport.style.fontSize = '1.2em';
    jsTrace.viewport.style.margin   = '0';
    jsTrace.viewport.style.padding  = '0 3px';
    jsTrace.viewport.style.position = 'absolute';
    jsTrace.viewport.style.top      = '30px';
    jsTrace.viewport.style.left     = '2px';
    jsTrace.viewport.style.overflow = 'auto';
    jsTrace.adjustViewport();
    jsTrace.window.appendChild( jsTrace.viewport );
    document.getElementsByTagName( 'body' )[0].appendChild( jsTrace.window );
    if( typeof( Drag ) != 'undefined' ){ // make it draggable
      Drag.init( header, jsTrace.window );
      jsTrace.window.onDragEnd = function(){
                                   jsTrace.setCookie();
                                 };
    }
  },
  // resizing stuff
  resizeX: function( x, grip ){
    var width    = parseInt( jsTrace.window.style.width );
    var newWidth = Math.abs( width - ( x - grip.xFrom ) ) + 'px';
    if( parseInt( newWidth ) < parseInt( jsTrace.window.style.minWidth ) )
      newWidth = jsTrace.window.style.minWidth;
    jsTrace.window.style.width = newWidth;
    grip.xFrom = x;
  },
  resizeY: function( y, grip ){
    var height    = parseInt( jsTrace.window.style.height );
    var newHeight = Math.abs( height - ( y - grip.yFrom ) ) + 'px';
    if( parseInt( newHeight ) < parseInt( jsTrace.window.style.minHeight ) )
      newHeight = jsTrace.window.style.minHeight;
    jsTrace.window.style.height = newHeight;
    grip.yFrom = y;
  },
  // adjust viewport
  adjustViewport: function(){
    jsTrace.viewport.style.width = ( parseInt( jsTrace.window.style.width ) - 8 ) + 'px';
    jsTrace.viewport.style.height = ( parseInt( jsTrace.window.style.height ) - 55 ) + 'px';
  },
  // send data too the window
  send: function( text ){
    text = text + "<br />";
    if( jsTrace.viewport == null ){  /* store in the buffer if the 
                                        viewport has not yet been built */
      jsTrace.buffer += text;
    } else {
      jsTrace.viewport.innerHTML += text;
      jsTrace.scrollWithIt();
    }
  },
  // send the buffer to the window
  sendBuffer: function(){
    if( jsTrace.viewport == null ){
      jsTrace.timer = window.setTimeout( 'jsTrace.sendBuffer()', 500 );
    } else {
      jsTrace.viewport.innerHTML += jsTrace.buffer;
      jsTrace.scrollWithIt();
      jsTrace.killTimer();
    }
  },
  // adjust the viewport to keep pace with the latest entries
  scrollWithIt: function(){
    jsTrace.viewport.scrollTop = jsTrace.viewport.scrollHeight;
  },
  // kill the window
  killWindow: function() {
    jsTrace.window.parentNode.removeChild( jsTrace.window );
    jsTrace.debugging_on = false;
  },
  // cookie handlers
  setCookie: function(){
    var posn = jsTrace.window.style.top + ' ' + jsTrace.window.style.left;
    var size = jsTrace.window.style.height + ' ' + jsTrace.window.style.width;
    document.cookie = 'jsTrace=' + escape( posn + ' ' + size );
  },
  getCookie: function(){
    if( !document.cookie ) return;
    var all_cookies = document.cookie;
    var found_at = all_cookies.indexOf('jsTrace=');
    if( found_at != -1 ){
      var start = found_at + 'jsTrace='.length;
      var end   = all_cookies.indexOf( ';', start );
      var value = ( end != -1 ) ? all_cookies.substring( start, end )
                                : all_cookies.substring( start );
      value = unescape( value );
      var vals = value.split( ' ' );
      // start with position
      jsTrace.window.style.top  = vals[0];
      jsTrace.window.style.left = vals[1];
      // then size
      jsTrace.window.style.height = vals[2];
      jsTrace.window.style.width  = vals[3];
      jsTrace.adjustViewport();
    }
  },
  // generic timer setup (if needed)
  timer: null,
  killTimer: function(){
    clearTimeout( jsTrace.timer );
  },
  // event handlers
  addEvent: function( obj, type, fn ){
    if (obj.addEventListener) obj.addEventListener( type, fn, false );
    else if (obj.attachEvent) {
      obj["e"+type+fn] = fn;
      obj[type+fn] = function() {
        obj["e"+type+fn]( window.event );
      };
      obj.attachEvent( "on"+type, obj[type+fn] );
    }
  },
  removeEvent: function ( obj, type, fn ) {
    if (obj.removeEventListener) obj.removeEventListener( type, fn, false );
    else if (obj.detachEvent) {
      obj.detachEvent( "on"+type, obj[type+fn] );
      obj[type+fn] = null;
      obj["e"+type+fn] = null;
    }
  },
  
  /*----------------------------------------------------------------------------
                              Add-on Tool Functions
  ----------------------------------------------------------------------------*/
  // send a delimeter to the window
  sendDelimeter: function(){
    jsTrace.send( '<span style="color: #f00">--------------------</span>' );
  },
  // send a delimeter to the window
  clearWindow: function(){
    jsTrace.viewport.innerHTML = '';
  }
  
};
jsTrace.addEvent( window, 'load', jsTrace.init );
jsTrace.addEvent( window, 'load', jsTrace.sendBuffer );



/**************************************************
 * dom-drag.js
 * 09.25.2001
 * www.youngpup.net
 **************************************************
 * 10.28.2001 - fixed minor bug where events
 * sometimes fired off the handle, not the root.
 **************************************************/

var Drag = {

	obj : null,

	init : function(o, oRoot, minX, maxX, minY, maxY, bSwapHorzRef, bSwapVertRef, fXMapper, fYMapper)
	{
		o.onmousedown	= Drag.start;

		o.hmode			= bSwapHorzRef ? false : true ;
		o.vmode			= bSwapVertRef ? false : true ;

		o.root = oRoot && oRoot != null ? oRoot : o ;

		if (o.hmode  && isNaN(parseInt(o.root.style.left  ))) o.root.style.left   = "0px";
		if (o.vmode  && isNaN(parseInt(o.root.style.top   ))) o.root.style.top    = "0px";
		if (!o.hmode && isNaN(parseInt(o.root.style.right ))) o.root.style.right  = "0px";
		if (!o.vmode && isNaN(parseInt(o.root.style.bottom))) o.root.style.bottom = "0px";

		o.minX	= typeof minX != 'undefined' ? minX : null;
		o.minY	= typeof minY != 'undefined' ? minY : null;
		o.maxX	= typeof maxX != 'undefined' ? maxX : null;
		o.maxY	= typeof maxY != 'undefined' ? maxY : null;

		o.xMapper = fXMapper ? fXMapper : null;
		o.yMapper = fYMapper ? fYMapper : null;

		o.root.onDragStart	= new Function();
		o.root.onDragEnd	= new Function();
		o.root.onDrag		= new Function();
	},

	start : function(e)
	{
		var o = Drag.obj = this;
		e = Drag.fixE(e);
		var y = parseInt(o.vmode ? o.root.style.top  : o.root.style.bottom);
		var x = parseInt(o.hmode ? o.root.style.left : o.root.style.right );
		o.root.onDragStart(x, y);

		o.lastMouseX	= e.clientX;
		o.lastMouseY	= e.clientY;

		if (o.hmode) {
			if (o.minX != null)	o.minMouseX	= e.clientX - x + o.minX;
			if (o.maxX != null)	o.maxMouseX	= o.minMouseX + o.maxX - o.minX;
		} else {
			if (o.minX != null) o.maxMouseX = -o.minX + e.clientX + x;
			if (o.maxX != null) o.minMouseX = -o.maxX + e.clientX + x;
		}

		if (o.vmode) {
			if (o.minY != null)	o.minMouseY	= e.clientY - y + o.minY;
			if (o.maxY != null)	o.maxMouseY	= o.minMouseY + o.maxY - o.minY;
		} else {
			if (o.minY != null) o.maxMouseY = -o.minY + e.clientY + y;
			if (o.maxY != null) o.minMouseY = -o.maxY + e.clientY + y;
		}

		document.onmousemove	= Drag.drag;
		document.onmouseup		= Drag.end;

		return false;
	},

	drag : function(e)
	{
		e = Drag.fixE(e);
		var o = Drag.obj;

		var ey	= e.clientY;
		var ex	= e.clientX;
		var y = parseInt(o.vmode ? o.root.style.top  : o.root.style.bottom);
		var x = parseInt(o.hmode ? o.root.style.left : o.root.style.right );
		var nx, ny;

		if (o.minX != null) ex = o.hmode ? Math.max(ex, o.minMouseX) : Math.min(ex, o.maxMouseX);
		if (o.maxX != null) ex = o.hmode ? Math.min(ex, o.maxMouseX) : Math.max(ex, o.minMouseX);
		if (o.minY != null) ey = o.vmode ? Math.max(ey, o.minMouseY) : Math.min(ey, o.maxMouseY);
		if (o.maxY != null) ey = o.vmode ? Math.min(ey, o.maxMouseY) : Math.max(ey, o.minMouseY);

		nx = x + ((ex - o.lastMouseX) * (o.hmode ? 1 : -1));
		ny = y + ((ey - o.lastMouseY) * (o.vmode ? 1 : -1));

		if (o.xMapper)		nx = o.xMapper(y)
		else if (o.yMapper)	ny = o.yMapper(x)

		Drag.obj.root.style[o.hmode ? "left" : "right"] = nx + "px";
		Drag.obj.root.style[o.vmode ? "top" : "bottom"] = ny + "px";
		Drag.obj.lastMouseX	= ex;
		Drag.obj.lastMouseY	= ey;

		Drag.obj.root.onDrag(nx, ny);
		return false;
	},

	end : function()
	{
		document.onmousemove = null;
		document.onmouseup   = null;
		Drag.obj.root.onDragEnd(	parseInt(Drag.obj.root.style[Drag.obj.hmode ? "left" : "right"]), 
									parseInt(Drag.obj.root.style[Drag.obj.vmode ? "top" : "bottom"]));
		Drag.obj = null;
	},

	fixE : function(e)
	{
		if (typeof e == 'undefined') e = window.event;
		if (typeof e.layerX == 'undefined') e.layerX = e.offsetX;
		if (typeof e.layerY == 'undefined') e.layerY = e.offsetY;
		return e;
	}
};