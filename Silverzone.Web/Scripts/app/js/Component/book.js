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
var book_1 = require("../Model/book"); // Use '../' to move out from directory
var bookService_1 = require("../Services/bookService");
var userService_1 = require("../Services/userService");
var bookFunctions_1 = require("../Shared/bookFunctions");
// sometimes we see >  _ngcontent-c1 with our HTML page bcoz 
// if we use any style with our HTML page or inside component with 'style' atribute
var bookList_Component = (function () {
    function bookList_Component(bookService, userSvc) {
        this.bookService = bookService;
        this.userSvc = userSvc;
        this.srchModel = new book_1.bookSearch_model();
    }
    bookList_Component.prototype.ngOnInit = function () {
        // on load of this component > this method will be call to get data from services
        this.get_Books(this.srchModel);
    };
    bookList_Component.prototype.get_Books = function (model) {
        var _this = this;
        this.bookService.searchBooks(model)
            .subscribe(function (books) {
            _this.bookList = books.result;
            _this.get_Bundles(model.classId);
        }, // this is type safe contains object
        function (error) { return console.log(error); });
    };
    bookList_Component.prototype.get_Bundles = function (classId) {
        var _this = this;
        this.bookService.getbook_bundles(classId)
            .subscribe(function (bundles) { return _this.bundleList = bundles.result; }, function (error) { return console.log(error); });
    };
    bookList_Component.prototype.serchBook = function (model) {
        this.get_Books(model);
    };
    bookList_Component.prototype.uploadImage = function (event) {
        var _this = this;
        var fileList = event.target.files;
        if (fileList.length > 0) {
            this.userSvc.uploadImage(fileList)
                .subscribe(function (data) { return _this.ProfilePic = data.result[0]; }, function (error) { return console.log(error); });
        }
    };
    return bookList_Component;
}());
bookList_Component = __decorate([
    core_1.Component({
        moduleId: module.id,
        //selector: 'book-list',    // no need to define bcoz this component load by routing
        templateUrl: '/templates/views/Book/book_list.html',
    }),
    __metadata("design:paramtypes", [bookService_1.bookService,
        userService_1.userService])
], bookList_Component);
exports.bookList_Component = bookList_Component;
var bookDetail_Component = (function () {
    function bookDetail_Component(rsc, route, bookService) {
        this.rsc = rsc;
        this.route = route;
        this.bookService = bookService;
    }
    bookDetail_Component.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (param) {
            var bookId = param['bookId'];
            _this.get_BookDetail(parseInt(bookId));
        });
    };
    bookDetail_Component.prototype.get_BookDetail = function (bookId) {
        var _this = this;
        this.bookService.get_bookDetail(bookId)
            .subscribe(function (books) {
            _this.bookDetail = books.result;
        }, function (error) { return console.log(error); });
    };
    // **************************  Cart  ******************
    bookDetail_Component.prototype.onkeyPress = function ($event) {
        $event.value = this.rsc.checkCart_Value(parseInt($event.value));
    };
    bookDetail_Component.prototype.changeQty = function ($event, is_AddQty) {
        $event.value = this.rsc.get_newQty($event.value, is_AddQty);
    };
    bookDetail_Component.prototype.addToCart = function (bookQty) {
        this.rsc.add_bookInCart(this.bookDetail.book_info, parseInt(bookQty.toString()));
    };
    bookDetail_Component.prototype.ngOnDestroy = function () {
        // Clean sub to avoid memory leak
        this.sub.unsubscribe();
    };
    return bookDetail_Component;
}());
bookDetail_Component = __decorate([
    core_1.Component({
        selector: 'book-detail',
        templateUrl: '/templates/views/Book/book_detail.html',
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction,
        router_1.ActivatedRoute,
        bookService_1.bookService])
], bookDetail_Component);
exports.bookDetail_Component = bookDetail_Component;
//# sourceMappingURL=book.js.map