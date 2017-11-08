import { Component, Inject, OnInit } from '@angular/core';
import { MD_DIALOG_DATA, MdDialogRef, MdSnackBar } from '@angular/material';
import { FormBuilder, Validators } from '@angular/forms';

import { authService } from '../Services/authService';
import { bookService } from '../Services/bookService';


@Component({
    selector: 'login-modal',
    templateUrl: '/templates/modal/userLoginModal.html',
})
export class loginModalComponent implements OnInit {
    userName: string = '';

    constructor(
        @Inject(MD_DIALOG_DATA) private entity: any,
        private authSvc: authService,
        private snackBar: MdSnackBar,
        private dialogRef: MdDialogRef<any>) { }    // dialogRef use to close popup on html page

    public ngOnInit() {
        this.userName = this.entity.userName;
    }

    onSubmit(formData: any) {
        this.authSvc
            .Login(Object.assign(formData, { verificationMode: 1 }))    // Object.assign is like angular.extend()
            .subscribe(
            (data: any) => {
                if (data === 'ok') {
                    this.snackBar.open('You have successfully login !', '', { duration: 3000 });
                    this.dialogRef.close(true);
                }
                else if (data === 'invalid')
                    this.snackBar.open('username or password is incorrect', '', { duration: 3000 });
                else if (data === 'notfound')
                    this.snackBar.open('You are not registered with us. Please sign up.', '', { duration: 3000 });
                else if (data === 'error')
                    this.snackBar.open('Something went wrong :(, Try again !', '', { duration: 3000 });
                else
                    this.snackBar.open('User role is not authorize !', '', { duration: 3000 });
            },
            (error: any) => console.log(error)
            );
    }

}

@Component({
    selector: 'country-modal',
    template: ` <div md-dialog-title>   
                <h4 style="margin: 0px !important;"class="box-title">Select Your Country</h4>         
                <button type="button" class="close" style="margin-top: -20px !important;" md-dialog-close>×</button> </div>       
                <md-dialog-content style="padding: 15px 15px !important;">
                <md-radio-group [(ngModel)]="countryId">                    
                <md-radio-button name="rd" value="1" class="col-md-6">India</md-radio-button>
                <md-radio-button name="rd" value="2">Outside India</md-radio-button>
                </md-radio-group> </md-dialog-content> <md-dialog-actions class="pull-right">
                <button class="btn btn-info" (click)="dialogRef.close(countryId)" md-raised-button>OK</button> </md-dialog-actions> `,
})
export class countryModalComponent {
    countryId: number;
    constructor(private dialogRef: MdDialogRef<any>) { }
}

@Component({
    //selector: 'login-modal',
    templateUrl: '/templates/modal/user_shipping_Addressform.html',
})
export class user_shipping_AddressModalComponent {
    user_shipping_Form: any;

    constructor(
        private authSvc: authService,
        private formBuilder: FormBuilder
    ) {
        this.user_shipping_Form = this.formBuilder.group({
            'name': ['', Validators.required],
            'email': ['', [Validators.required, Validators.email]],
            'mobile': ['', [Validators.required, Validators.minLength(10)]]
        });
    }

    save_user_shipping_Address() {
        alert('form is submited');
    }
    
}


@Component({
    template: `<div *ngIf="bundle.bundleInfo"><div class="modal-header" style="padding: 8px !important;"> 
                 <h4 class="box-title" [innerHtml]="bundle.bundleInfo.Name"></h4>
                 <button type="button" class="close" style="margin-top: -30px !important;"> 
                 <span aria-hidden="true" (click)="dialogRef.close()">×</span>
               </button> </div>
               <div class="modal-body">
                 <div class="row"> 
                    <div class="col-sm-12">
                      <h4> This Combo includes following Items :-</h4> 
                 </div> </div> 
               <div class="col-sm-6 text-danger" style="font-size: larger;">
                  <span class="text-info">Total Price : </span>
                  <strong><i class="fa fa-inr"></i> </strong>
                  <span [innerHtml]="bundle.bundleInfo.books_totalPrice" style="text-decoration: line-through;"></span> </div> 
               <div class="col-sm-6 text-warning text-right" style="font-size: larger;">
               <span class="text-info">Combo Price :</span> <strong>
                  <i class="fa fa-inr"></i> </strong> 
                  <span [innerHtml]="bundle.bundleInfo.bundle_totalPrice"></span></div> 
               <div class="row" style="margin-top: 50px;"> 
               <div *ngFor="let bookInfo of bundle.bookInfo; let lastIndex = last;">
               <div class="col-sm-3" style="padding: 5px;">
                   <img [src]="bookInfo.BookImage" class="img-responsive" style="margin: 0 auto; height:170px;">
                   <div class="text-center"> <div class="name-container">
                        <a href="#" [innerHtml]="bookInfo.title"></a></div> 
                   <div class="price" style="margin: 6px 0px 6px 0px;"> 
                   <strong><i class="fa fa-inr"></i> </strong>
                   <span [innerHtml]="bookInfo.price"></span></div>
               </div></div>
               <div class="col-sm-1"
                    style="width: 25px !important; padding: 0px !important; margin-top: 10%;"
                    *ngIf="!lastIndex">
                       <i class="fa fa-plus fa-2x" style="color: burlywood;"></i>
               </div></div></div></div>`,
})
export class bundle_Modal {
    private bundle: any = {};

    constructor(
        @Inject(MD_DIALOG_DATA) entity: any,
        bookSvc: bookService,
        private dialogRef: MdDialogRef<any>)
    {        
        bookSvc.get_bookBundleDetail(entity.bundleId)
            .subscribe(
            (data: any) => this.bundle = data.result[0],
            (error: any) => console.log(error)
            );
    }
    
}
