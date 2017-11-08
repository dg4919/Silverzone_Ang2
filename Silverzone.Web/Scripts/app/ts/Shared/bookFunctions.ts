import { Injectable } from '@angular/core';
import { MdSnackBar } from '@angular/material';

import { cartItem_snackBarComponent } from '../component/snackbars';
import { entity, cart_books } from '../Model/book';

// this is a kind of service which does not have @Component decorator > so we use it by inject
@Injectable()           // use to emit Metadata of service
export class bookFunction {

    // using private we can't access 'snackBar' object in other injected class
    constructor(public snackBar: MdSnackBar) { }

    //  ------- global fxs ----------
    buyBook_isDisable: Array<boolean> = [];   // by default members r public

    // cart is type of entity(strict type so can't assign other type of value like integer/string)
    cart: entity = new entity();   // initialise value to use it

    add_bookInCart(
        bookInfo: any,
        itemQty: number
    ) {

        // when coupon Info is not null & book_newPrice have some value then it will assign otherwise > bookInfo.Price
        var bookPrice = parseFloat(bookInfo.CouponInfo && bookInfo.CouponInfo.book_newPrice.toString())
            || parseFloat(bookInfo.Price.toString());

        let _cart_books: cart_books = new cart_books();

        _cart_books.bookId = bookInfo.BookId;
        _cart_books.bookImage = bookInfo.BookImage;
        _cart_books.bookTitle = bookInfo.book_title + ' : ' + bookInfo.Category + ' - ' + bookInfo.Class;
        _cart_books.bookTotalPrice = bookPrice * itemQty;
        _cart_books.bookQty = itemQty;
        _cart_books.bookPrice = bookPrice;
        _cart_books.bookPublisher = bookInfo.Publisher;
        _cart_books.Subject = bookInfo.Subject;
        _cart_books.bookType = 1;     // for books

        // use to show text > Added' OR 'Buy Now' option with Book list
        this.buyBook_isDisable[bookInfo.BookId] = true;

        // show notification of adding item in cart using Ang material snackbar
        this.snackBar.openFromComponent(cartItem_snackBarComponent, {
            duration: 3000,       // if not set, will pe show permanently
        });

        this.add_update_Cart(_cart_books);
    }


    add_bundleInCart(
        bundleInfo: any,
        itemQty: number
    ) {

        let _cart_books: cart_books = new cart_books();

        _cart_books.bookId = bundleInfo.Id;
        _cart_books.bookImage = 'Images/bundle.jpg';
        _cart_books.bookTitle = bundleInfo.Name + ' : ' + 'Bundle' + ' - ' + bundleInfo.className;
        _cart_books.bookTotalPrice = bundleInfo.bundle_totalPrice * itemQty;
        _cart_books.bookQty = itemQty;
        _cart_books.bookPrice = bundleInfo.bundle_totalPrice;
        _cart_books.bookPublisher = 'Silverzone';
        _cart_books.Subject = 'Books Bundle';
        _cart_books.bookType = 2;     // for boundle

        // show notification of adding item in cart using Ang material snackbar
        this.snackBar.openFromComponent(cartItem_snackBarComponent, {
            duration: 3000,       // if not set, will pe show permanently
        });

        this.add_update_Cart(_cart_books);
    }

    // for first time add item into cart
    private add_update_Cart(bookInfo: cart_books) {
        var item_notFound = true;

        this.cart.Items.forEach((data, index) => {

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
    }

    private set_shippingAmt() {
        this.cart.shipping_Amount = this.cart.Items.map(function (data, index) {
            return data.bookTotalPrice;
        })                                  // return only books price
            .reduce((a, b) => a + b);       // sum of list 
    }

    // to check value is integer or not > while keypress in cart quantity
    checkCart_Value(item_qty: number) {

        // NaN become true if > Qty doesn't have any value or have a string
        return (isNaN(item_qty) || item_qty === 0 ? 1 : item_qty);
    }

    // function with returning value = type of number.. So we can't retrn other type value [this is optional]
    get_newQty(itemQty: number,
        isAdd_qty: boolean): number {

        // true for Add Qty 
        if (isAdd_qty) {
            itemQty < 99 ? itemQty++ : 99;
        }
        else {
            itemQty > 1 ? itemQty-- : 1
        }

        return itemQty;
    }
   
    update_CartQty(selectedIndex: number,
        newQty: number) {

        // loop each element & if found then return value
        this.cart.Items.forEach((data, index) => {
            if (index === selectedIndex) {       // means element is found
                data.bookQty = newQty;
                data.bookTotalPrice = data.bookPrice * newQty;
                return;                         // exit from this loop
            }
        });

        this.set_shippingAmt();
    }

    set_shippingCharges(country_code: number) {

        var item_qty = this.cart.Items.map(function (data, index) {
            return data.bookQty;
        })
            .reduce((a, b) => a + b);

        this.cart.shipping_Charges = country_code === 1
            ? 40 + (item_qty - 1) * 25
            : 1200 + (item_qty - 1) * 200
    }

}

