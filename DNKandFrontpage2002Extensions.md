#describes some issues with frontpage extensions and DNK

# Introduction #

Frontpage 2002 server extensions, which allow for easy website editing and publishing, appears to break URL rewriting in DotNetKicks

# Symptoms #

The DNK main page can be accessed, but links to other pages on the website return the 404 Not Found error page.


# Details #

Frontpage 2002 Server Extensions appear to interfere with URLRewriting.NET, the url rewriting package used by DotNetKicks.  This has been found to be reproducible on web servers that have the following features:

  * Windows Server 2003 64bit, SP 1
  * IIS is running in 32bit compatibility mode OR in 64bit mode
  * Frontpage 2002 Server Extensions 64bit is installed

The extensions can be installed before or after a DNK website is set up.  It does not matter if the DNK website is extended via the server extension or not.

# Fixes/Workarounds #

Uninstalling FSE does not fix the issue.  Only a server backup restoration or a complete wipe is guaranteed to fix the issue.  It is suggested that the web server be configured to use WebDAV or FTP for publishing.