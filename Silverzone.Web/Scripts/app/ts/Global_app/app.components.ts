// all components, directive will be register here :)

// main app TS files  >> components
import { HomeComponent, MenuComponent } from '../Component/home';
import { bookDetail_Component, bookList_Component } from '../Component/book';
import { CartBoxComponent,  viewCart_Component } from '../Component/cart';
import { shpingAdresComponent } from '../Component/user';

// Directives/ partial components
import {
    bindBooks_directiveComponent,
    bindBundle_directiveComponent,
    bookSearch_directiveComponent,
    cartAction_directiveComponent,
    ControlMessages,
    HiddenDirective,
    dynamicComponent,
    Comp1Component,
    Comp2Component,
} from '../Component/customDirective';    // Use './' for current directory

// modal component
import {
    loginModalComponent,
    countryModalComponent,
    user_shipping_AddressModalComponent,
    bundle_Modal
} from '../Component/modal';

// snack bars for notifiaction msgs
import {
    cartItem_snackBarComponent,
    country_snackBarComponent
} from '../component/snackbars';

export const _components = [
    HomeComponent,
    MenuComponent,
    CartBoxComponent,
    bookList_Component,
    bookDetail_Component,
    viewCart_Component,
    shpingAdresComponent
];

export const _directives = [
    bindBooks_directiveComponent,
    bindBundle_directiveComponent,
    bookSearch_directiveComponent,
    cartAction_directiveComponent,
    ControlMessages,
    HiddenDirective,
    dynamicComponent,
];

export const _modals = [
    loginModalComponent,
    countryModalComponent,
    user_shipping_AddressModalComponent,
    bundle_Modal,
    Comp1Component,
    Comp2Component,
];

export const _snackBars = [
    cartItem_snackBarComponent,
    country_snackBarComponent
];


