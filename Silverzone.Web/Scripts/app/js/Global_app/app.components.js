// all components, directive will be register here :)
"use strict";
// main app TS files  >> components
var home_1 = require("../Component/home");
var book_1 = require("../Component/book");
var cart_1 = require("../Component/cart");
var user_1 = require("../Component/user");
// Directives/ partial components
var customDirective_1 = require("../Component/customDirective"); // Use './' for current directory
// modal component
var modal_1 = require("../Component/modal");
// snack bars for notifiaction msgs
var snackbars_1 = require("../component/snackbars");
exports._components = [
    home_1.HomeComponent,
    home_1.MenuComponent,
    cart_1.CartBoxComponent,
    book_1.bookList_Component,
    book_1.bookDetail_Component,
    cart_1.viewCart_Component,
    user_1.shpingAdresComponent
];
exports._directives = [
    customDirective_1.bindBooks_directiveComponent,
    customDirective_1.bindBundle_directiveComponent,
    customDirective_1.bookSearch_directiveComponent,
    customDirective_1.cartAction_directiveComponent,
    customDirective_1.ControlMessages,
    customDirective_1.HiddenDirective,
    customDirective_1.dynamicComponent,
];
exports._modals = [
    modal_1.loginModalComponent,
    modal_1.countryModalComponent,
    modal_1.user_shipping_AddressModalComponent,
    modal_1.bundle_Modal,
    customDirective_1.Comp1Component,
    customDirective_1.Comp2Component,
];
exports._snackBars = [
    snackbars_1.cartItem_snackBarComponent,
    snackbars_1.country_snackBarComponent
];
//# sourceMappingURL=app.components.js.map