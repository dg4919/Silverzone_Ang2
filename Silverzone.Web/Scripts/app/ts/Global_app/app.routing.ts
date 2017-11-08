import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// from main directory > from Ts find path
import { bookList_Component, bookDetail_Component } from '../Component/book';    // Use '../' to move out from directory
import { viewCart_Component } from '../Component/cart';
import { shpingAdresComponent } from '../Component/user';

import { AuthManager } from '../Shared/AuthManager';

const appRoutes: Routes = [
    {
        path: 'Book/List',       // no need to provide '/' as prefix in rote string,
        component: bookList_Component
    },
    {
        path: 'Book/Info/:bookId/:bookTitle',
        component: bookDetail_Component
    },
    {
        path: 'viewCart',
        component: viewCart_Component
    },
    {
        path: 'shippingAddress',
        component: shpingAdresComponent,
        canActivate: [AuthManager]
    },
    {
        path: '**',  // otherwise route.
        component: bookList_Component
    }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
