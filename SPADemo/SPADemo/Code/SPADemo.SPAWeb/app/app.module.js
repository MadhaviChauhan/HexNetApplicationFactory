//The root module which will have all the child modules, this is required as on the mvc view when we use ng-view and use
//more than one module and controller to load content. we cannot use multiple ng-view. for this we need root app module.
var app = angular.module('app', ['app.customer','app.order','ui.bootstrap']);
