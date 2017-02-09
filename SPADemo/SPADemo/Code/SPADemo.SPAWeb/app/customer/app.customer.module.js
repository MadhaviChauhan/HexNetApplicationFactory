
//module initialization for customer module, this should also include all the modules injection which would be requiring in further operations
//ui.bootstrap for using modal dialog
//ui.grid for all grid related operations and to register core api's of grid
//ui.grid.selection for allowing row selection on click of row inside grid
//ui.grid.edit for inline row edit
//ui.grid.pagination for all pagination related funtionality
//ui.grid.resizeColumns for feature to allow resizing of columns generated from server code.
//ngRoute for using routing for url's
var appcustomer = angular.module('app.customer', ['ngRoute','ui.bootstrap', 'ui.grid', 'ui.grid.selection', 'ui.grid.edit', 'ui.grid.pagination', 'ui.grid.resizeColumns']);



