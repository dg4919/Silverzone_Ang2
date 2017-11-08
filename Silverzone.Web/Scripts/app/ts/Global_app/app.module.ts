/*
  this directory contain files wich will be use for this module/project
  this is the main Startup file > Main Startup file must be inside main directive
  menas main directory > Then other component file inside child directory
  
  TS gives compile time error checking :) Like C#
*/

// finds ts files > it contain common modules for application :)
import { NgModule } from '@angular/core';    // find from [node_modules] that is main directory
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from '@angular/material';

import { app_services } from '../Global_app/app.services';   // Use '../' to move from current directory
import { CommonModule } from '../Global_app/common.module';   // Use '../' to move from current directory

import {
    _components,
    _directives,
    _modals,
    _snackBars
} from '../Global_app/app.components';   // Use '../' to move from current directory

// Use './' for same directory Ts file
import { Routing } from './app.routing';        // exist in same directory

//----------------- let/var can be used >  let keyword of TypeScript -------------------------------

@NgModule({
    imports: [      // all Modules will inject Here > dependency to run app
        BrowserModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpModule,
        MaterialModule,
        Routing,
        CommonModule
    ],
    declarations: [
        _components,
        _directives,
        _modals,
        _snackBars,
    ],   // inject all components/directive/filters here
    entryComponents: [  // All modal components, register here :) OR dynamically show/hide compnent will add here
        _modals,
        _snackBars
    ],
    providers: [                  // Global Service Providers
        app_services
    ],
    bootstrap: [_components[0]],   // starting first page > inject 'component' which we want to show
})
export class AppModule { }
