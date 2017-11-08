import { Injectable } from '@angular/core';
import { MdDialog } from '@angular/material';

import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import {
    loginModalComponent,
    countryModalComponent,
    user_shipping_AddressModalComponent,
    bundle_Modal
} from '../Component/modal';

@Injectable()
export class modalService {

    constructor(
        private router: Router,
        public dialog: MdDialog) { }

    get_loginModal() {
        let dialogRef = this.dialog.open(loginModalComponent, {
            height: '320px',
            width: '500px',
            data: { userName: 'Divya' }
        });

        return dialogRef.afterClosed();
    }

    get_countryModal() {
        let dialogRef = this.dialog.open(countryModalComponent, {
            height: '195px',
            width: '300px'
        });

        return dialogRef.afterClosed();
    }

    get_userShippingModal() {
        let dialogRef = this.dialog.open(user_shipping_AddressModalComponent, {
            width: '550px'
        });

        return dialogRef.afterClosed();
    }

    get_bundleModal(_bundleId: number) {
        let dialogRef = this.dialog.open(bundle_Modal, {
            height: '550px',
            width: '800px',
            data: { bundleId: _bundleId }
        });
        return dialogRef.afterClosed();
    }

}
