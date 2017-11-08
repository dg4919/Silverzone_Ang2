"use strict";
var router_1 = require("@angular/router");
// from main directory > from Ts find path
var book_1 = require("../Component/book"); // Use '../' to move out from directory
var cart_1 = require("../Component/cart");
var user_1 = require("../Component/user");
var AuthManager_1 = require("../Shared/AuthManager");
var appRoutes = [
    {
        path: 'Book/List',
        component: book_1.bookList_Component
    },
    {
        path: 'Book/Info/:bookId/:bookTitle',
        component: book_1.bookDetail_Component
    },
    {
        path: 'viewCart',
        component: cart_1.viewCart_Component
    },
    {
        path: 'shippingAddress',
        component: user_1.shpingAdresComponent,
        canActivate: [AuthManager_1.AuthManager]
    },
    {
        path: '**',
        component: book_1.bookList_Component
    }
];
exports.Routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map