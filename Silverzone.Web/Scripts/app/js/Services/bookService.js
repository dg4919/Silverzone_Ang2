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
var httpService_1 = require("../Shared/httpService");
var constants_1 = require("../Shared/constants");
var bookService = (function () {
    function bookService(httpSvc) {
        this.httpSvc = httpSvc;
        this.apiUrl = constants_1.globalConfig.apiEndPoint + constants_1.globalConfig.version.Site;
    }
    // by default public
    bookService.prototype.get_bookDetail = function (book_Id) {
        var params = new http_1.URLSearchParams();
        params.set('bookId', book_Id.toString());
        var url = this.apiUrl + "/Book/get_bookDetail_byId";
        return this.httpSvc.GetCache(url, params);
    };
    bookService.prototype.get_bookBundleDetail = function (bundleId) {
        var params = new http_1.URLSearchParams();
        params.set('bundleId', bundleId.toString());
        var url = this.apiUrl + "/Book/get_bookBundleDetail_byId";
        return this.httpSvc.GetCache(url, params);
    };
    bookService.prototype.searchBooks = function (model) {
        var params = new http_1.URLSearchParams();
        params.set('classId', model.classId);
        params.set('subjectId', model.subjectId);
        if (model.cateogysId.length)
            params.set('book_categoriesId', model.cateogysId);
        var url = this.apiUrl + "/Book/searchBooks";
        // save the result for 1st time & use it again & again
        return this.httpSvc.GetCache(url, params);
    };
    bookService.prototype.getbook_bundles = function (class_id) {
        var params = new http_1.URLSearchParams();
        params.set('classId', class_id.toString());
        var url = this.apiUrl + "/Book/getbook_bundles";
        return this.httpSvc.GetCache(url, params);
    };
    bookService.prototype.getAll_class = function () {
        var url = this.apiUrl + "/Book/getAllClass";
        return this.httpSvc.GetCache(url);
    };
    bookService.prototype.get_subject_byClassId = function (_classId) {
        var params = new http_1.URLSearchParams();
        params.set('classId', _classId.toString());
        var url = this.apiUrl + "/Subject/Get_subjects_ByclassId";
        return this.httpSvc.GetCache(url, params);
    };
    bookService.prototype.get_bookCategorys = function () {
        var url = this.apiUrl + "/Category/category_List";
        return this.httpSvc.GetCache(url);
    };
    return bookService;
}());
bookService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [httpService_1.httpService])
], bookService);
exports.bookService = bookService;
//# sourceMappingURL=bookService.js.map