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
var core_1 = require("@angular/core");
var stringFilter = (function () {
    function stringFilter() {
    }
    // Transform is the new "return function(value, args)" in Angular 1.x
    stringFilter.prototype.transform = function (value) {
        return (value.trim().replace(/ /g, '-')); // replace space with '-' in a string
    };
    return stringFilter;
}());
stringFilter = __decorate([
    core_1.Pipe({
        name: 'stringFilter'
    }),
    __metadata("design:paramtypes", [])
], stringFilter);
exports.stringFilter = stringFilter;
//# sourceMappingURL=filters.js.map