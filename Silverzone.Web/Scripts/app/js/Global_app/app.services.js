// all filters, services will be register here :)
"use strict";
// filter is our services which inject in decalration part like component
var filters_1 = require("../Shared/filters");
exports._filters = [
    filters_1.stringFilter
];
// services
var authService_1 = require("../Services/authService");
var httpService_1 = require("../Shared/httpService");
var AuthManager_1 = require("../Shared/AuthManager");
exports.shared_services = [
    httpService_1.httpService,
    authService_1.authService,
    AuthManager_1.AuthManager,
];
// Global Services going here
var bookFunctions_1 = require("../Shared/bookFunctions");
var bookService_1 = require("../Services/bookService");
var userService_1 = require("../Services/userService");
var modalService_1 = require("../Services/modalService");
exports.app_services = [
    { provide: 'book_comonFunction', useClass: bookFunctions_1.bookFunction },
    bookService_1.bookService,
    userService_1.userService,
    modalService_1.modalService
];
//# sourceMappingURL=app.services.js.map