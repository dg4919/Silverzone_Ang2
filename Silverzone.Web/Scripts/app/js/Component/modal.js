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
var material_1 = require("@angular/material");
var forms_1 = require("@angular/forms");
var authService_1 = require("../Services/authService");
var bookService_1 = require("../Services/bookService");
var loginModalComponent = (function () {
    function loginModalComponent(entity, authSvc, snackBar, dialogRef) {
        this.entity = entity;
        this.authSvc = authSvc;
        this.snackBar = snackBar;
        this.dialogRef = dialogRef;
        this.userName = '';
    } // dialogRef use to close popup on html page
    loginModalComponent.prototype.ngOnInit = function () {
        this.userName = this.entity.userName;
    };
    loginModalComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.authSvc
            .Login(Object.assign(formData, { verificationMode: 1 })) // Object.assign is like angular.extend()
            .subscribe(function (data) {
            if (data === 'ok') {
                _this.snackBar.open('You have successfully login !', '', { duration: 3000 });
                _this.dialogRef.close(true);
            }
            else if (data === 'invalid')
                _this.snackBar.open('username or password is incorrect', '', { duration: 3000 });
            else if (data === 'notfound')
                _this.snackBar.open('You are not registered with us. Please sign up.', '', { duration: 3000 });
            else if (data === 'error')
                _this.snackBar.open('Something went wrong :(, Try again !', '', { duration: 3000 });
            else
                _this.snackBar.open('User role is not authorize !', '', { duration: 3000 });
        }, function (error) { return console.log(error); });
    };
    return loginModalComponent;
}());
loginModalComponent = __decorate([
    core_1.Component({
        selector: 'login-modal',
        templateUrl: '/templates/modal/userLoginModal.html',
    }),
    __param(0, core_1.Inject(material_1.MD_DIALOG_DATA)),
    __metadata("design:paramtypes", [Object, authService_1.authService,
        material_1.MdSnackBar,
        material_1.MdDialogRef])
], loginModalComponent);
exports.loginModalComponent = loginModalComponent;
var countryModalComponent = (function () {
    function countryModalComponent(dialogRef) {
        this.dialogRef = dialogRef;
    }
    return countryModalComponent;
}());
countryModalComponent = __decorate([
    core_1.Component({
        selector: 'country-modal',
        template: " <div md-dialog-title>   \n                <h4 style=\"margin: 0px !important;\"class=\"box-title\">Select Your Country</h4>         \n                <button type=\"button\" class=\"close\" style=\"margin-top: -20px !important;\" md-dialog-close>\u00D7</button> </div>       \n                <md-dialog-content style=\"padding: 15px 15px !important;\">\n                <md-radio-group [(ngModel)]=\"countryId\">                    \n                <md-radio-button name=\"rd\" value=\"1\" class=\"col-md-6\">India</md-radio-button>\n                <md-radio-button name=\"rd\" value=\"2\">Outside India</md-radio-button>\n                </md-radio-group> </md-dialog-content> <md-dialog-actions class=\"pull-right\">\n                <button class=\"btn btn-info\" (click)=\"dialogRef.close(countryId)\" md-raised-button>OK</button> </md-dialog-actions> ",
    }),
    __metadata("design:paramtypes", [material_1.MdDialogRef])
], countryModalComponent);
exports.countryModalComponent = countryModalComponent;
var user_shipping_AddressModalComponent = (function () {
    function user_shipping_AddressModalComponent(authSvc, formBuilder) {
        this.authSvc = authSvc;
        this.formBuilder = formBuilder;
        this.user_shipping_Form = this.formBuilder.group({
            'name': ['', forms_1.Validators.required],
            'email': ['', [forms_1.Validators.required, forms_1.Validators.email]],
            'mobile': ['', [forms_1.Validators.required, forms_1.Validators.minLength(10)]]
        });
    }
    user_shipping_AddressModalComponent.prototype.save_user_shipping_Address = function () {
        alert('form is submited');
    };
    return user_shipping_AddressModalComponent;
}());
user_shipping_AddressModalComponent = __decorate([
    core_1.Component({
        //selector: 'login-modal',
        templateUrl: '/templates/modal/user_shipping_Addressform.html',
    }),
    __metadata("design:paramtypes", [authService_1.authService,
        forms_1.FormBuilder])
], user_shipping_AddressModalComponent);
exports.user_shipping_AddressModalComponent = user_shipping_AddressModalComponent;
var bundle_Modal = (function () {
    function bundle_Modal(entity, bookSvc, dialogRef) {
        var _this = this;
        this.dialogRef = dialogRef;
        this.bundle = {};
        bookSvc.get_bookBundleDetail(entity.bundleId)
            .subscribe(function (data) { return _this.bundle = data.result[0]; }, function (error) { return console.log(error); });
    }
    return bundle_Modal;
}());
bundle_Modal = __decorate([
    core_1.Component({
        template: "<div *ngIf=\"bundle.bundleInfo\"><div class=\"modal-header\" style=\"padding: 8px !important;\"> \n                 <h4 class=\"box-title\" [innerHtml]=\"bundle.bundleInfo.Name\"></h4>\n                 <button type=\"button\" class=\"close\" style=\"margin-top: -30px !important;\"> \n                 <span aria-hidden=\"true\" (click)=\"dialogRef.close()\">\u00D7</span>\n               </button> </div>\n               <div class=\"modal-body\">\n                 <div class=\"row\"> \n                    <div class=\"col-sm-12\">\n                      <h4> This Combo includes following Items :-</h4> \n                 </div> </div> \n               <div class=\"col-sm-6 text-danger\" style=\"font-size: larger;\">\n                  <span class=\"text-info\">Total Price : </span>\n                  <strong><i class=\"fa fa-inr\"></i> </strong>\n                  <span [innerHtml]=\"bundle.bundleInfo.books_totalPrice\" style=\"text-decoration: line-through;\"></span> </div> \n               <div class=\"col-sm-6 text-warning text-right\" style=\"font-size: larger;\">\n               <span class=\"text-info\">Combo Price :</span> <strong>\n                  <i class=\"fa fa-inr\"></i> </strong> \n                  <span [innerHtml]=\"bundle.bundleInfo.bundle_totalPrice\"></span></div> \n               <div class=\"row\" style=\"margin-top: 50px;\"> \n               <div *ngFor=\"let bookInfo of bundle.bookInfo; let lastIndex = last;\">\n               <div class=\"col-sm-3\" style=\"padding: 5px;\">\n                   <img [src]=\"bookInfo.BookImage\" class=\"img-responsive\" style=\"margin: 0 auto; height:170px;\">\n                   <div class=\"text-center\"> <div class=\"name-container\">\n                        <a href=\"#\" [innerHtml]=\"bookInfo.title\"></a></div> \n                   <div class=\"price\" style=\"margin: 6px 0px 6px 0px;\"> \n                   <strong><i class=\"fa fa-inr\"></i> </strong>\n                   <span [innerHtml]=\"bookInfo.price\"></span></div>\n               </div></div>\n               <div class=\"col-sm-1\"\n                    style=\"width: 25px !important; padding: 0px !important; margin-top: 10%;\"\n                    *ngIf=\"!lastIndex\">\n                       <i class=\"fa fa-plus fa-2x\" style=\"color: burlywood;\"></i>\n               </div></div></div></div>",
    }),
    __param(0, core_1.Inject(material_1.MD_DIALOG_DATA)),
    __metadata("design:paramtypes", [Object, bookService_1.bookService,
        material_1.MdDialogRef])
], bundle_Modal);
exports.bundle_Modal = bundle_Modal;
//# sourceMappingURL=modal.js.map