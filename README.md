Javascript Mvc Route Helper
=======================

This helper allows you to access to MVC routes in your Javascript files.

It provides a Javascript equivalent of Url.Action.

Usage
-----
1. Add a reference to Sor.JavascriptMvcRouteHelper in your MVC Project.

2. Add a new route in the Global.asax file. The route must be of type Sor.JavascriptMvcRouteHelper.DiscoverableRoute, must be the first route and must not use the action parameter.
```c#
routes.Add(new Sor.JavascriptMvcRouteHelper.DiscoverableRoute("discoverableroute/{controller}"));
```

3. Update your controller class for which you want to access to MVC routes by extending Sor.JavascriptMvcRouteHelper.DiscoverableController.

4. To access to the actions urls of a controller, add a reference to a script using the route declared in the step 2.
```html
<script src="/discoverableroute/{controller-name}"></script>
```
Replace {controller-name} with the name of your controller.

5. To access to the routes, use the variable $mvc.
```javascript
$mvc.Account.LogOn
```
For example, use this instruction to access to the URL of the LogOn action of the Account controller.

More informations
-----------------
GitHub Repository : https://github.com/sebastieno/JavascriptMvcRouteHelper

Nuget package : https://nuget.org/packages/JavascriptMvcRouteHelper

More informations about the implementation just here (in French only) : http://sebastienollivier.fr/blog/asp-net-mvc/liste-actions/