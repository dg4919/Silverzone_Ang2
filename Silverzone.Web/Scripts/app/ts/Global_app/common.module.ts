import { NgModule } from '@angular/core';    // find from [node_modules] that is main directory

import {
    _filters,
    shared_services
} from '../Global_app/app.services';   // Use '../' to move from current directory

@NgModule({
    declarations: [
        _filters,     
    ],      // inject all components/directive/filters here
    exports: [_filters],   // export component to use witth other module
    providers: [                  // Global Service Providers
        shared_services
    ],
})
export class CommonModule { }
