import { Component, OnInit } from '@angular/core';

import { userService } from '../Services/userService'
import { modalService } from '../Services/modalService'

@Component({
    //selector: 'user:Shipping_Adrdess',
    templateUrl: '/templates/views/Cart/user_address.html',
    styles: [`
    .panel_color:hover {
        border: 1px solid #ff8787 !important;
    }

    .mrgTop {
        margin-top: 50px;
    }
`]
})
export class shpingAdresComponent implements OnInit {
    private shippingAdressList: any = [];

    constructor(
        private userSvc: userService,
        private shippingAdresModal: modalService) { }

    ngOnInit() {
        this.get_userShipingAdres();
    }

    private get_userShipingAdres() {
        this.userSvc.getUser_shippingAdress()
            .subscribe(
            (data: any) => this.shippingAdressList = data.result,
            (error: any) => console.log(error)
            );
    }

    show_userAdress_modal() {
        this.shippingAdresModal.get_userShippingModal();
    }
}
