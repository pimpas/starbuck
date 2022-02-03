# starbuck simulation app
there is a swagger in https://localhost:44342/swagger/index.html where is possible to consult and test all methods in the API.

Current issue:
the entity framework is getting an error in saving async method related with disposed object. (need to check this, but the service is registered as scoped)
the entity framework is also having a problem with numeric types.

Things i would like to improve:
-Add automapper and more view model objects.
-Add a custom controller that has access to custom responses and uses properly the INotificator interface.
-Return the correct response code in all controllers.
-Add claims so that some methods are only available to authorized users.
-Use of git ignore.
