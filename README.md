ShiftPlanning ASP SDK
================

The [ShiftPlanning API](http://www.humanity.com/api/) allows you to call modules within the ShiftPlanning [employee scheduling software](http://www.humanity.com/) that respond in REST style JSON & XML.

This repository contains the open source ASP SDK that allows you to utilize the
above on your website. Except as otherwise noted, the ShiftPlanning ASP SDK
is licensed under the Apache Licence, Version 2.0
(http://www.apache.org/licenses/LICENSE-2.0.html)


Usage
-----

The [examples][examples] are a good place to start. The minimal you'll need to
have is:

	<%

	objshiftPlaning = new shiftPlaning("XXXXXXXXXXXXXXXXXX"); // enter your developer key

	// This will return you your token to further API Calls.

To make [API][API] calls:

	shiftPlaning objshiftPlaning = new shiftPlaning("XXXXXXXXXXXXXXXXXX");
	objshiftPlaning.Token ="ABCDEFGHIJK"; // your token key
	string responseXml = objshiftPlaning.doLogin("youremailaddress","password");

To Logout

	string response = objshiftPlaning.doLogout();
	#In response xml you will find status node value as 1, meaning you have successfully logged out.

[examples]: https://github.com/shiftplanning/ASP-SDK/tree/master/examples/
[API]: http://www.humanity.com/api/


Feedback
--------

We are relying on the [GitHub issues tracker][issues] linked from above for
feedback. File bugs or other issues [here][issues].

[issues]: http://github.com/shiftplanning/ASP-SDK/issues