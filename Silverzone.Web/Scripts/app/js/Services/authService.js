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
var http_1 = require("@angular/http");
var Rx_1 = require("rxjs/Rx");
var constants_1 = require("../Shared/constants");
var authService = (function () {
    // bcoz here in constructor have another depedency (Http).. so if we inject this service then it will throw error while creating object of this (bookService) class
    // thats wyy we r using @Injectable() to omit the metadata of injected classess (http)
    function authService(http) {
        this.http = http;
        this.currentUser = {};
        this.isLoggedIn = false;
        this.apiUrl = constants_1.globalConfig.apiEndPoint + constants_1.globalConfig.version.Site;
        this.currentUser = JSON.parse(localStorage.getItem('auth_user'));
    }
    authService.prototype.Login = function (model) {
        var _this = this;
        var url = this.apiUrl + "/Account/Login";
        return this.http
            .post(url, model) // search : params is predefined
            .map(function (res) {
            var data = res.json();
            if (data.result === 'ok')
                _this.setUser(data);
            return data.result;
        })
            .catch(function (error) { return Rx_1.Observable.throw(error.toString() || 'Server error'); });
    };
    authService.prototype.setUser = function (userInfo) {
        // directly mereg new object into userInfo.user
        Object.assign(userInfo.user, { token: userInfo.token.access_token });
        this.currentUser = userInfo.user;
        this.isLoggedIn = true;
        // local storage store user info in browser & when ever user clear history then it will also removed
        //localStorage.setItem('auth_token', userInfo.token.access_token);
        localStorage.setItem('auth_user', userInfo.user);
    };
    return authService;
}());
authService = __decorate([
    core_1.Injectable() // use to emit Metadata of service
    ,
    __metadata("design:paramtypes", [http_1.Http])
], authService);
exports.authService = authService;
//# sourceMappingURL=authService.js.map