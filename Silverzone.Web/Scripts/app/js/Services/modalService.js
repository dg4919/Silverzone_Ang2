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
var core_1 = require("@angular/core");
var material_1 = require("@angular/material");
var router_1 = require("@angular/router");
var modal_1 = require("../Component/modal");
var modalService = (function () {
    function modalService(router, dialog) {
        this.router = router;
        this.dialog = dialog;
    }
    modalService.prototype.get_loginModal = function () {
        var dialogRef = this.dialog.open(modal_1.loginModalComponent, {
            height: '320px',
            width: '500px',
            data: { userName: 'Divya' }
        });
        return dialogRef.afterClosed();
    };
    modalService.prototype.get_countryModal = function () {
        var dialogRef = this.dialog.open(modal_1.countryModalComponent, {
            height: '195px',
            width: '300px'
        });
        return dialogRef.afterClosed();
    };
    modalService.prototype.get_userShippingModal = function () {
        var dialogRef = this.dialog.open(modal_1.user_shipping_AddressModalComponent, {
            width: '550px'
        });
        return dialogRef.afterClosed();
    };
    modalService.prototype.get_bundleModal = function (_bundleId) {
        var dialogRef = this.dialog.open(modal_1.bundle_Modal, {
            height: '550px',
            width: '800px',
            data: { bundleId: _bundleId }
        });
        return dialogRef.afterClosed();
    };
    return modalService;
}());
modalService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [router_1.Router,
        material_1.MdDialog])
], modalService);
exports.modalService = modalService;
//# sourceMappingURL=modalService.js.map