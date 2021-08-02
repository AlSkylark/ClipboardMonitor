# Clipboard Monitor - Link/Mail Opener
This small application is quite simple but with a very specific purpose for the company that required it. 
They use Microsoft Access as their main database and use an RDP connection to their small server where said database is. 
However, due to this server being very old and underspecced they only use it as the "Database Portal" of sorts.

So they needed a way to open url links OUTSIDE the RDP connection, in their local laptops. Because I couldn't find any easy way 
to transfer commands, what I did is create a Clipboard monitor that looks for a specific keyword. If found, it would minimize
the RDP process and then open the link (after cleaning the string into a proper url). 

In the Access side clicking on the hyperlink only has a "copy to clipboard" action with said keyword in front of it, like so: 
[KEYWORD][URL]
Effectively looking like the link is being opened as expected from the outside. 

Additionally, we required a way to have that "RDP Access" connect with the Outlook profile OUTSIDE the RDP, so I applied the same
kind of logic as the Link Opener, but with a different keyword.

In the Access side, the string is built like this: [KEYWORD][NAME]$ID$[CONTACTID]$EM$[EMAIL]

Upon detecting the new keyword, the program will break down this string by their identifiers ($ID$, and $EM$, customizable) and 
put them in a small struct to then be passed into an Outlook MailItem object and display it on screen ready to be sent if all is well.

A very specific and small program that has proven quite useful given the particular set of circumstances! 
