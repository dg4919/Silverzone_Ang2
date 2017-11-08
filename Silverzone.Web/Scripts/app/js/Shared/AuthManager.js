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
var modalService_1 = require("../Services/modalService");
var AuthManager = (function () {
    function AuthManager(router, dialog, loginModalSvc) {
        this.router = router;
        this.dialog = dialog;
        this.loginModalSvc = loginModalSvc;
    }
    AuthManager.prototype.canActivate = function (next, state) {
        var _this = this;
        if (localStorage.getItem('auth_user'))
            return true;
        // show login Modal =>  when user is not looged in
        this.loginModalSvc.get_loginModal()
            .subscribe(function (res) {
            if (res)
                _this.router.navigate([state.url]);
        });
    };
    return AuthManager;
}());
AuthManager = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [router_1.Router,
        material_1.MdDialog,
        modalService_1.modalService])
], AuthManager);
exports.AuthManager = AuthManager;
//# sourceMappingURL=AuthManager.js.map