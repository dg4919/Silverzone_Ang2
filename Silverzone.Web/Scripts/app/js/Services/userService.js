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
var httpService_1 = require("../Shared/httpService");
var constants_1 = require("../Shared/constants");
var userService = (function () {
    function userService(httpSvc, http) {
        this.httpSvc = httpSvc;
        this.http = http;
        this.apiUrl = constants_1.globalConfig.apiEndPoint + constants_1.globalConfig.version.Site;
        this.user_api = constants_1.globalConfig.apiEndPoint + constants_1.globalConfig.version.User;
    }
    userService.prototype.getUser_shippingAdress = function () {
        var url = this.apiUrl + "/Order/get_shipping_Address_byUserId";
        return this.httpSvc.Get(url);
    };
    userService.prototype.uploadImage = function (files) {
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append("file", files[i]);
        }
        var header = new http_1.Headers();
        //header.append('Content-Type', 'multipart/form-data');
        //header.append('Accept', 'application/json');
        var options = new http_1.RequestOptions({ headers: header });
        var url = this.user_api + "/UserProfile/uploaduserImage";
        return this.http.post(url, formData, options)
            .map(function (res) { return res.json(); })
            .catch(function (error) { return Rx_1.Observable.throw(error); });
    };
    return userService;
}());
userService = __decorate([
    core_1.Injectable() // use to emit Metadata of service
    ,
    __metadata("design:paramtypes", [httpService_1.httpService,
        http_1.Http])
], userService);
exports.userService = userService;
//# sourceMappingURL=userService.js.map