// in interface we can not assign value of property/members & can not create object like > var a = new cart_books() but can defaine a variable type (var a : new cart_books)
// we can use interfaces in a method to provide parameter type 
"use strict";
var bookSearch_model = (function () {
    function bookSearch_model() {
        this.classId = 1;
        this.subjectId = '';
        this.cateogysId = [];
    }
    return bookSearch_model;
}());
exports.bookSearch_model = bookSearch_model;
// required properties for cart
var cart_books = (function () {
    function cart_books() {
    }
    return cart_books;
}());
exports.cart_books = cart_books;
var entity = (function () {
    function entity() {
        this.Items = new Array(); // Items is type of cart_books[] having empty array
        this.shipping_Amount = 0; // type safe > can't assign string > thrown error
        this.shipping_Charges = 0; // define values so that property is shown while debugging
        //total_Amount: number = 0;           // can be anything
        this.CountryType = 0;
    }
    return entity;
}());
exports.entity = entity;
//# sourceMappingURL=book.js.map