import { Component, Inject } from '@angular/core';

import { modalService } from '../Services/modalService';

import { authService } from '../Services/authService';
import { bookFunction } from '../Shared/bookFunctions';

@Component({
    // template bind with <home>'template would be display here'</home>
    // but if don't use selector then  <ng-component>'template would be display here'</ng-component>
    selector: 'home',   
    templateUrl: '/templates/views/home.html',
})
export class HomeComponent {
}


// multiple component using at a time
@Component({
    selector: 'menu-Item',
    templateUrl: '/templates/Partials/Menu.html',
})
// clasess r attach with above Component
export class MenuComponent {
    constructor(
        @Inject('book_comonFunction') private rsc: bookFunction,
        private userSvc: authService,
        private loginModalSvc: modalService) { }

    login() {        
        this.loginModalSvc.get_loginModal();
    }

}
