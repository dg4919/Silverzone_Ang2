import { Component } from '@angular/core';

@Component({
    template: ` <p class="text-center"> 
                <i class="fa fa-bell txt-color"></i>
                Item added in your cart ! </p> `,
    styles: [`
    p.text-center {
        color: #fff;
        font-size: 17px;
    }
    .txt-color {
    color: #50adfd !important;
    }
`]
})
export class cartItem_snackBarComponent { }

@Component({
    template: ` <p class="text-center"> 
                <i class="fa fa-exclamation-circle txt-color"></i>
                Select your country ! </p> `,
    styles: [`
    p.text-center {
        color: #fff;
        font-size: 17px;
    }
    .txt-color {
    color: #ff6161 !important;
    }
`]
})
export class country_snackBarComponent { }
