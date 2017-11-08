/*
  this directory contain files wich will be use for this module/project
  this is the main Startup file > Main Startup file must be inside main directive
  menas main directory > Then other component file inside child directory
  
  TS gives compile time error checking :) Like C#
*/
"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
// finds ts files > it contain common modules for application :)
var core_1 = require("@angular/core"); // find from [node_modules] that is main directory
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var animations_1 = require("@angular/platform-browser/animations");
var material_1 = require("@angular/material");
var app_services_1 = require("../Global_app/app.services"); // Use '../' to move from current directory
var common_module_1 = require("../Global_app/common.module"); // Use '../' to move from current directory
var app_components_1 = require("../Global_app/app.components"); // Use '../' to move from current directory
// Use './' for same directory Ts file
var app_routing_1 = require("./app.routing"); // exist in same directory
//----------------- let/var can be used >  let keyword of TypeScript -------------------------------
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.ReactiveFormsModule,
            animations_1.BrowserAnimationsModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            material_1.MaterialModule,
            app_routing_1.Routing,
            common_module_1.CommonModule
        ],
        declarations: [
            app_components_1._components,
            app_components_1._directives,
            app_components_1._modals,
            app_components_1._snackBars,
        ],
        entryComponents: [
            app_components_1._modals,
            app_components_1._snackBars
        ],
        providers: [
            app_services_1.app_services
        ],
        bootstrap: [app_components_1._components[0]],
    }),
    __metadata("design:paramtypes", [])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map