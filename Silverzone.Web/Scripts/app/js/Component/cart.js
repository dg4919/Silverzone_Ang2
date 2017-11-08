"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var snackbars_1 = require("../component/snackbars");
var bookFunctions_1 = require("../Shared/bookFunctions");
var modalService_1 = require("../Services/modalService");
var CartBoxComponent = (function () {
    // this private must use at time of DI
    function CartBoxComponent(rsc, router, modalSvc) {
        this.rsc = rsc;
        this.router = router;
        this.modalSvc = modalSvc;
    }
    CartBoxComponent.prototype.proceed = function () {
        var _this = this;
        this.modalSvc.get_countryModal()
            .subscribe(function (countryCode) {
            var cntryCode = parseInt(countryCode);
            if (cntryCode) {
                _this.rsc.cart.CountryType = cntryCode;
                _this.rsc.set_shippingCharges(cntryCode);
                _this.router.navigate(['/viewCart']);
            }
            else
                _this.rsc.snackBar.openFromComponent(snackbars_1.country_snackBarComponent, {
                    duration: 3000,
                });
        });
    };
    CartBoxComponent.prototype.onTitleClick = function (bookInfo) {
        if (bookInfo.bookType === 2)
            this.modalSvc.get_bundleModal(bookInfo.bookId);
    };
    return CartBoxComponent;
}());
CartBoxComponent = __decorate([
    core_1.Component({
        selector: 'cart_Box',
        templateUrl: '/templates/Partials/cartBox.html',
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction,
        router_1.Router,
        modalService_1.modalService])
], CartBoxComponent);
exports.CartBoxComponent = CartBoxComponent;
var viewCart_Component = (function () {
    function viewCart_Component(rsc) {
        this.rsc = rsc;
    }
    return viewCart_Component;
}());
viewCart_Component = __decorate([
    core_1.Component({
        selector: 'view:cart',
        templateUrl: '/templates/views/Cart/cart_detail.html',
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction])
], viewCart_Component);
exports.viewCart_Component = viewCart_Component;
//# sourceMappingURL=cart.js.map