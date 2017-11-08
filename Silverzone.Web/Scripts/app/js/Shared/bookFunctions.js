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
var snackbars_1 = require("../component/snackbars");
var book_1 = require("../Model/book");
// this is a kind of service which does not have @Component decorator > so we use it by inject
var bookFunction = (function () {
    // using private we can't access 'snackBar' object in other injected class
    function bookFunction(snackBar) {
        this.snackBar = snackBar;
        //  ------- global fxs ----------
        this.buyBook_isDisable = []; // by default members r public
        // cart is type of entity(strict type so can't assign other type of value like integer/string)
        this.cart = new book_1.entity(); // initialise value to use it
    }
    bookFunction.prototype.add_bookInCart = function (bookInfo, itemQty) {
        // when coupon Info is not null & book_newPrice have some value then it will assign otherwise > bookInfo.Price
        var bookPrice = parseFloat(bookInfo.CouponInfo && bookInfo.CouponInfo.book_newPrice.toString())
            || parseFloat(bookInfo.Price.toString());
        var _cart_books = new book_1.cart_books();
        _cart_books.bookId = bookInfo.BookId;
        _cart_books.bookImage = bookInfo.BookImage;
        _cart_books.bookTitle = bookInfo.book_title + ' : ' + bookInfo.Category + ' - ' + bookInfo.Class;
        _cart_books.bookTotalPrice = bookPrice * itemQty;
        _cart_books.bookQty = itemQty;
        _cart_books.bookPrice = bookPrice;
        _cart_books.bookPublisher = bookInfo.Publisher;
        _cart_books.Subject = bookInfo.Subject;
        _cart_books.bookType = 1; // for books
        // use to show text > Added' OR 'Buy Now' option with Book list
        this.buyBook_isDisable[bookInfo.BookId] = true;
        // show notification of adding item in cart using Ang material snackbar
        this.snackBar.openFromComponent(snackbars_1.cartItem_snackBarComponent, {
            duration: 3000,
        });
        this.add_update_Cart(_cart_books);
    };
    bookFunction.prototype.add_bundleInCart = function (bundleInfo, itemQty) {
        var _cart_books = new book_1.cart_books();
        _cart_books.bookId = bundleInfo.Id;
        _cart_books.bookImage = 'Images/bundle.jpg';
        _cart_books.bookTitle = bundleInfo.Name + ' : ' + 'Bundle' + ' - ' + bundleInfo.className;
        _cart_books.bookTotalPrice = bundleInfo.bundle_totalPrice * itemQty;
        _cart_books.bookQty = itemQty;
        _cart_books.bookPrice = bundleInfo.bundle_totalPrice;
        _cart_books.bookPublisher = 'Silverzone';
        _cart_books.Subject = 'Books Bundle';
        _cart_books.bookType = 2; // for boundle
        // show notification of adding item in cart using Ang material snackbar
        this.snackBar.openFromComponent(snackbars_1.cartItem_snackBarComponent, {
            duration: 3000,
        });
        this.add_update_Cart(_cart_books);
    };
    // for first time add item into cart
    bookFunction.prototype.add_update_Cart = function (bookInfo) {
        var item_notFound = true;
        this.cart.Items.forEach(function (data, index) {
            if (data.bookId === bookInfo.bookId && data.bookType === bookInfo.bookType) {
                // necessary fields will update
                data.bookTotalPrice = bookInfo.bookTotalPrice;
                data.bookQty = bookInfo.bookQty;
                item_notFound = false;
            }
        });
        if (item_notFound) {
            this.cart.Items.push(bookInfo);
        }
        this.set_shippingAmt();
    };
    bookFunction.prototype.set_shippingAmt = function () {
        this.cart.shipping_Amount = this.cart.Items.map(function (data, index) {
            return data.bookTotalPrice;
        }) // return only books price
            .reduce(function (a, b) { return a + b; }); // sum of list 
    };
    // to check value is integer or not > while keypress in cart quantity
    bookFunction.prototype.checkCart_Value = function (item_qty) {
        // NaN become true if > Qty doesn't have any value or have a string
        return (isNaN(item_qty) || item_qty === 0 ? 1 : item_qty);
    };
    // function with returning value = type of number.. So we can't retrn other type value [this is optional]
    bookFunction.prototype.get_newQty = function (itemQty, isAdd_qty) {
        // true for Add Qty 
        if (isAdd_qty) {
            itemQty < 99 ? itemQty++ : 99;
        }
        else {
            itemQty > 1 ? itemQty-- : 1;
        }
        return itemQty;
    };
    bookFunction.prototype.update_CartQty = function (selectedIndex, newQty) {
        // loop each element & if found then return value
        this.cart.Items.forEach(function (data, index) {
            if (index === selectedIndex) {
                data.bookQty = newQty;
                data.bookTotalPrice = data.bookPrice * newQty;
                return; // exit from this loop
            }
        });
        this.set_shippingAmt();
    };
    bookFunction.prototype.set_shippingCharges = function (country_code) {
        var item_qty = this.cart.Items.map(function (data, index) {
            return data.bookQty;
        })
            .reduce(function (a, b) { return a + b; });
        this.cart.shipping_Charges = country_code === 1
            ? 40 + (item_qty - 1) * 25
            : 1200 + (item_qty - 1) * 200;
    };
    return bookFunction;
}());
bookFunction = __decorate([
    core_1.Injectable() // use to emit Metadata of service
    ,
    __metadata("design:paramtypes", [material_1.MdSnackBar])
], bookFunction);
exports.bookFunction = bookFunction;
//# sourceMappingURL=bookFunctions.js.map