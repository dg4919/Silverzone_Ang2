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
var modalService_1 = require("../Services/modalService");
var authService_1 = require("../Services/authService");
var bookFunctions_1 = require("../Shared/bookFunctions");
var HomeComponent = (function () {
    function HomeComponent() {
    }
    return HomeComponent;
}());
HomeComponent = __decorate([
    core_1.Component({
        // template bind with <home>'template would be display here'</home>
        // but if don't use selector then  <ng-component>'template would be display here'</ng-component>
        selector: 'home',
        templateUrl: '/templates/views/home.html',
    }),
    __metadata("design:paramtypes", [])
], HomeComponent);
exports.HomeComponent = HomeComponent;
// multiple component using at a time
var MenuComponent = (function () {
    function MenuComponent(rsc, userSvc, loginModalSvc) {
        this.rsc = rsc;
        this.userSvc = userSvc;
        this.loginModalSvc = loginModalSvc;
    }
    MenuComponent.prototype.login = function () {
        this.loginModalSvc.get_loginModal();
    };
    return MenuComponent;
}());
MenuComponent = __decorate([
    core_1.Component({
        selector: 'menu-Item',
        templateUrl: '/templates/Partials/Menu.html',
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction,
        authService_1.authService,
        modalService_1.modalService])
], MenuComponent);
exports.MenuComponent = MenuComponent;
//# sourceMappingURL=home.js.map