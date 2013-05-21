Created by: Tordeur Kenny

Contact:
--------
Email: kenny.tordeur@gmail.com
Twitter: @KennyTordeur
Blog: http://kennytordeur.blogspot.com

TODO:
-----
In the App_Start folder a file called Mef.Config is added. The "RegisterMef" method has to be executed only once. 
Add it to the Global.asax in the Application_Start() method.

Remarks:
--------
Your WebApi controllers must be decorated with  [Export] and [PartCreationPolicy(CreationPolicy.NonShared)]. Otherwise
you WebApi controller will not import the requested types.

This is a personal project of mine and i have succesfully implemented it in a few person projects.
It's not been tested in production environments so use it at your own risk.

More information about the implementation off this package can be found here: http://kennytordeur.blogspot.be/2012/08/mef-in-aspnet-mvc-4-and-webapi.html

If you have any questions, remarks or bugs (hopefully not) feel free to contact them to me.

Happy coding ...