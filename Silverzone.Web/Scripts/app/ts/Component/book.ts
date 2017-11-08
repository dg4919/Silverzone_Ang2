import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { bookSearch_model } from '../Model/book';      // Use '../' to move out from directory
import { bookService } from '../Services/bookService';
import { userService } from '../Services/userService';
import { bookFunction } from '../Shared/bookFunctions';

// sometimes we see >  _ngcontent-c1 with our HTML page bcoz 
// if we use any style with our HTML page or inside component with 'style' atribute
@Component({
    moduleId: module.id,
    //selector: 'book-list',    // no need to define bcoz this component load by routing
    templateUrl: '/templates/views/Book/book_list.html',
    //providers: [bookService],  // provider is available only to its child component.. so just need to inject service
})
export class bookList_Component implements OnInit {
    private bookList: any;
    private bundleList: any;
    private ProfilePic: string;
    private srchModel = new bookSearch_model();

    constructor(
        private bookService: bookService,
        private userSvc: userService    ) { }

    public ngOnInit(): void {
        // on load of this component > this method will be call to get data from services
        this.get_Books(this.srchModel);
    }

    get_Books(model: bookSearch_model) {
        this.bookService.searchBooks(model)
            .subscribe(
            (books: any) => {
                this.bookList = books.result
                this.get_Bundles(model.classId);
            },      // this is type safe contains object
            (error: any) => console.log(error)
            );
    }

    get_Bundles(classId: number) {
        this.bookService.getbook_bundles(classId)
            .subscribe(
            bundles => this.bundleList = bundles.result,
            error => console.log(error)
            );
    }

    serchBook(model: bookSearch_model) {
        this.get_Books(model);
    }

    uploadImage(event: any) {
        let fileList: FileList = event.target.files;

        if (fileList.length > 0) {
            this.userSvc.uploadImage(fileList)
                .subscribe(
                (data: any) => this.ProfilePic = data.result[0],
                error => console.log(error)
                );
        }
    }

}


@Component({
    selector: 'book-detail',
    templateUrl: '/templates/views/Book/book_detail.html',
})
export class bookDetail_Component implements OnInit {
    private bookDetail: any;
    private sub: any;

    constructor(
        @Inject('book_comonFunction') private rsc: bookFunction,
        private route: ActivatedRoute,
        private bookService: bookService) { }

    public ngOnInit(): void {
        this.sub = this.route.params.subscribe((param: Params) => {
            let bookId = param['bookId'];
            this.get_BookDetail(parseInt(bookId));
        });
    }

    get_BookDetail(bookId: number) {
        this.bookService.get_bookDetail(bookId)
            .subscribe(
            (books: any) => {
                this.bookDetail = books.result;
            },
            (error: any) => console.log(error)
            );
    }

    // **************************  Cart  ******************
    onkeyPress($event: any) {
        $event.value = this.rsc.checkCart_Value(parseInt($event.value));
    }

    changeQty($event: any,
        is_AddQty: boolean) {
        $event.value = this.rsc.get_newQty($event.value, is_AddQty);
    }

    addToCart(bookQty: number) {
        this.rsc.add_bookInCart(
            this.bookDetail.book_info,
            parseInt(bookQty.toString())
        );
    }

    ngOnDestroy() {
        // Clean sub to avoid memory leak
        this.sub.unsubscribe();
    }

}

