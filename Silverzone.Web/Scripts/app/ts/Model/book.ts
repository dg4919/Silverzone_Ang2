// in interface we can not assign value of property/members & can not create object like > var a = new cart_books() but can defaine a variable type (var a : new cart_books)
// we can use interfaces in a method to provide parameter type 


export class bookSearch_model {
    classId: number = 1;
    subjectId: string = '';
    cateogysId: number[] = [];
}

// required properties for cart
export class cart_books {
    bookId: number;
    bookImage: string;
    bookTitle: string;
    bookCategory: string;
    bookClass: string;
    bookTotalPrice: number;
    bookQty: number;
    bookPrice: number;
    bookPublisher: string;
    Subject: string;
    bookSubject: string;
    bookType: number;     // for books
}

export class entity {
    Items: cart_books[] = new Array();    // Items is type of cart_books[] having empty array
    shipping_Amount: number = 0;          // type safe > can't assign string > thrown error
    shipping_Charges: number = 0          // define values so that property is shown while debugging
    //total_Amount: number = 0;           // can be anything
    CountryType: number = 0;
}
