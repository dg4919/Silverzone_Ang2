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
var caching_1 = require("./caching");
var authService_1 = require("../Services/authService");
var httpService = (function () {
    // bcoz here in constructor have another depedency (Http).. so if we inject this service then it will throw error while creating object of this (bookService) class =>  Can't resolve all parameters for bookService
    // thats wyy we r using @Injectable() to omit the metadata of injected classess (http)
    function httpService(http, authSvc) {
        this.http = http;
        this.authSvc = authSvc;
    }
    httpService.prototype.Get = function (url, params) {
        return this.http
            .get(url, this.getHeader(params))
            .map(function (res) { return res.json(); })
            .catch(function (error) { return Rx_1.Observable.throw(error.toString() || 'Server error'); });
    };
    httpService.prototype.GetCache = function (url, params) {
        return caching_1.cacheablee(this.http
            .get(url, this.getHeader(params)), caching_1.setCacheKey(url, params))
            .map(function (res) { return res.json(); })
            .catch(function (error) { return Rx_1.Observable.throw(error.toString() || 'Server error'); });
    };
    httpService.prototype.Post = function (url, model) {
        return this.http
            .post(url, this.getHeader())
            .map(function (res) { return res.json(); })
            .catch(function (error) { return Rx_1.Observable.throw(error.toString() || 'Server error'); });
    };
    httpService.prototype.getHeader = function (params) {
        var headers = new http_1.Headers();
        headers.append('Accept', 'application/json');
        headers.append('content-Type', 'application/json');
        if (this.authSvc.isLoggedIn)
            headers.append('Authorization', 'Bearer ' + this.authSvc.currentUser.token);
        if (params)
            return new http_1.RequestOptions({
                headers: headers,
                search: params
            });
        else
            return new http_1.RequestOptions({ headers: headers });
    };
    return httpService;
}());
httpService = __decorate([
    core_1.Injectable() // use to emit Metadata of service
    ,
    __metadata("design:paramtypes", [http_1.Http,
        authService_1.authService])
], httpService);
exports.httpService = httpService;
//# sourceMappingURL=httpService.js.map