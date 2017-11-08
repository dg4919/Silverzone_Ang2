//  this path contains Partial components / Directives
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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var validationService_1 = require("../Services/validationService");
var router_1 = require("@angular/router");
var book_1 = require("../Model/book");
var bookFunctions_1 = require("../Shared/bookFunctions");
var bookService_1 = require("../Services/bookService");
var filters_1 = require("../Shared/filters");
var bindBooks_directiveComponent = (function () {
    // register only dependency here :)
    function bindBooks_directiveComponent(rsc, // rsc is like a rootscope variable
        router, strFilter) {
        this.rsc = rsc;
        this.router = router;
        this.strFilter = strFilter;
    }
    bindBooks_directiveComponent.prototype.addtoCart = function (bookInfo) {
        this.rsc.add_bookInCart(bookInfo, 1);
    };
    bindBooks_directiveComponent.prototype.onSelect = function (bookInfo) {
        this.router.navigate(['/Book/Info', bookInfo.BookId, this.strFilter.transform(bookInfo.book_title)]);
    };
    return bindBooks_directiveComponent;
}());
bindBooks_directiveComponent = __decorate([
    core_1.Component({
        // dont use ':' = (book:info) > coz its bind only right part.. So use [book-info OR book_info]
        selector: 'book_info',
        templateUrl: '/templates/customDirective_template/bookList.html',
        providers: [filters_1.stringFilter],
        inputs: ['book'] // contains bookinfo used in template
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction,
        router_1.Router,
        filters_1.stringFilter])
], bindBooks_directiveComponent);
exports.bindBooks_directiveComponent = bindBooks_directiveComponent;
var bindBundle_directiveComponent = (function () {
    function bindBundle_directiveComponent(rsc) {
        this.rsc = rsc;
        this.bundleQty = [];
    }
    bindBundle_directiveComponent.prototype.onkeyPress = function ($event) {
        $event.value = this.rsc.checkCart_Value(parseInt($event.value));
    };
    bindBundle_directiveComponent.prototype.changeQty = function ($event, is_AddQty) {
        $event.value = this.rsc.get_newQty($event.value, is_AddQty);
    };
    bindBundle_directiveComponent.prototype.addCombo_toCart = function (bookBundleInfo, qty) {
        this.rsc.add_bundleInCart(bookBundleInfo, parseInt(qty.toString()));
    };
    return bindBundle_directiveComponent;
}());
bindBundle_directiveComponent = __decorate([
    core_1.Component({
        selector: 'bundle',
        templateUrl: '/templates/customDirective_template/bundleList.html',
        inputs: ['bundles']
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction])
], bindBundle_directiveComponent);
exports.bindBundle_directiveComponent = bindBundle_directiveComponent;
var bookSearch_directiveComponent = (function () {
    function bookSearch_directiveComponent(_bookService) {
        this._bookService = _bookService;
        this.srchModel = new book_1.bookSearch_model();
        this.onSearchBooks = new core_1.EventEmitter();
    }
    bookSearch_directiveComponent.prototype.ngOnInit = function () {
        this.get_AllClass();
        this.get_AllCategorys();
    };
    bookSearch_directiveComponent.prototype.get_AllClass = function () {
        var _this = this;
        this._bookService.getAll_class()
            .subscribe(function (data) {
            _this.classList = data.result;
            _this.get_Subjects(data.result[0].Id);
        }, function (error) { return console.log(error); });
    };
    bookSearch_directiveComponent.prototype.get_Subjects = function (classId) {
        var _this = this;
        this._bookService.get_subject_byClassId(classId)
            .subscribe(function (data) { return _this.subjectList = data.result; }, function (error) { return console.log(error); });
    };
    bookSearch_directiveComponent.prototype.get_AllCategorys = function () {
        var _this = this;
        this._bookService.get_bookCategorys()
            .subscribe(function (data) { return _this.categoryList = data.result; }, function (error) { return console.log(error); });
    };
    bookSearch_directiveComponent.prototype.srchBooks = function () {
        this.onSearchBooks.emit(this.srchModel);
    };
    return bookSearch_directiveComponent;
}());
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], bookSearch_directiveComponent.prototype, "onSearchBooks", void 0);
bookSearch_directiveComponent = __decorate([
    core_1.Component({
        selector: 'bookSearch',
        templateUrl: '/templates/Partials/book_search.html'
    }),
    __metadata("design:paramtypes", [bookService_1.bookService])
], bookSearch_directiveComponent);
exports.bookSearch_directiveComponent = bookSearch_directiveComponent;
var cartAction_directiveComponent = (function () {
    function cartAction_directiveComponent(rsc) {
        this.rsc = rsc;
    }
    cartAction_directiveComponent.prototype.onkeyPress = function (index, $event) {
        var newValu = this.rsc.checkCart_Value(parseInt($event.target.value));
        $event.target.value = newValu;
        this.changeQty(index, newValu, true, true);
    };
    cartAction_directiveComponent.prototype.changeQty = function (index, Qty, is_AddQty, key_event) {
        // bcoz fx returning value in string (thats wy convert its value)
        Qty = parseInt(Qty.toString());
        this.rsc.update_CartQty(index, key_event ? Qty : this.rsc.get_newQty(Qty, is_AddQty));
    };
    return cartAction_directiveComponent;
}());
cartAction_directiveComponent = __decorate([
    core_1.Component({
        selector: 'cartAction',
        template: " <button class=\"btn btn-default btn-guests btn-guests-minus btn-sm\" \n                        style=\"font-size: 7px !important;\"\n                        (click)=\"changeQty(currentIndex, cartQty, true)\">\n                    <span class=\"fa-stack\">\n                        <i class=\"fa fa-circle-thin fa-stack-2x\"></i>\n                        <i class=\"fa fa-plus fa-stack-1x\"></i>\n                    </span>\n                </button>\n                <input type=\"text\" style=\"width: 60px;text-align: center;\" maxlength=\"2\"\n                       [value]=\"cartQty\"\n                       (keyup)=\"onkeyPress(currentIndex, $event)\">\n                <button class=\"btn btn-default btn-guests btn-guests-plus btn-sm\" \n                        style=\"font-size: 7px !important;\"\n                        (click)=\"changeQty(currentIndex, cartQty, false)\">\n                    <span class=\"fa-stack\">\n                        <i class=\"fa fa-circle-thin fa-stack-2x\"></i>\n                        <i class=\"fa fa-minus fa-stack-1x\"></i>\n                    </span>\n                </button>",
        inputs: ['cartQty', 'currentIndex']
    }),
    __param(0, core_1.Inject('book_comonFunction')),
    __metadata("design:paramtypes", [bookFunctions_1.bookFunction])
], cartAction_directiveComponent);
exports.cartAction_directiveComponent = cartAction_directiveComponent;
var ControlMessages = (function () {
    function ControlMessages() {
        // get accessor is a function which return value and pass into errorMessage object
        // which can directly use into template
        //get errorMessage() {
        //    for (let propertyName in this.control.errors) {
        //        if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
        //            return ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
        //        }
        //    }
        //    return null;
        //}
        this.errorMessage = '';
    }
    ControlMessages.prototype.ngOnChanges = function (changes) {
        this.errorMessage = '';
        var errors = changes;
        console.log(errors);
        for (var propertyName in this.control.errors) {
            if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
                this.errorMessage = validationService_1.ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
            }
        }
    };
    return ControlMessages;
}());
__decorate([
    core_1.Input(),
    __metadata("design:type", forms_1.FormControl)
], ControlMessages.prototype, "control", void 0);
ControlMessages = __decorate([
    core_1.Component({
        selector: 'control-messages',
        template: "<span class=\"text-danger\"\n                     *ngIf=\"errorMessage !== null\">\n                 {{errorMessage}}\n               </span>"
    }),
    __metadata("design:paramtypes", [])
], ControlMessages);
exports.ControlMessages = ControlMessages;
var core_2 = require("@angular/core");
// Directive decorator
var HiddenDirective = (function () {
    function HiddenDirective(el, renderer) {
        this.el = el;
        this.renderer = renderer;
        // Use renderer to render the element with styles
        //renderer.setElementStyle(el.nativeElement, 'display', 'none');
    }
    HiddenDirective.prototype.onmouseover = function () {
        this.el.nativeElement.style.backgroundColor = 'yellow';
        //this.renderer.setElementStyle(this.el.nativeElement, 'background-color', '#1f1');
    };
    HiddenDirective.prototype.onmouseleave = function () {
        this.renderer.setElementStyle(this.el.nativeElement, 'background-color', '#ddd');
    };
    return HiddenDirective;
}());
__decorate([
    core_2.HostListener('mouseenter'),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], HiddenDirective.prototype, "onmouseover", null);
__decorate([
    core_2.HostListener('mouseleave'),
    __metadata("design:type", Function),
    __metadata("design:paramtypes", []),
    __metadata("design:returntype", void 0)
], HiddenDirective.prototype, "onmouseleave", null);
HiddenDirective = __decorate([
    core_2.Directive({ selector: '[myHidden]' }),
    __metadata("design:paramtypes", [core_2.ElementRef,
        core_2.Renderer])
], HiddenDirective);
exports.HiddenDirective = HiddenDirective;
var dynamicComponent = (function () {
    function dynamicComponent(_componentFactoryResolver) {
        this._componentFactoryResolver = _componentFactoryResolver;
    }
    dynamicComponent.prototype.onClik = function (val) {
        if (val === 1) {
            var componentFactory = this._componentFactoryResolver.resolveComponentFactory(Comp1Component);
            var componentRef = this.injectComp.createComponent(componentFactory);
        }
        else {
            var componentFactory = this._componentFactoryResolver.resolveComponentFactory(Comp2Component);
            var componentRef = this.injectComp.createComponent(componentFactory);
        }
    };
    return dynamicComponent;
}());
__decorate([
    core_2.ViewChild('dynamicContentPlaceHolder', { read: core_2.ViewContainerRef }),
    __metadata("design:type", core_2.ViewContainerRef)
], dynamicComponent.prototype, "injectComp", void 0);
dynamicComponent = __decorate([
    core_1.Component({
        selector: 'dynamic-component',
        template: "<button (click)=\"onClik(1)\">Clik Me</button>\n               <button (click)=\"onClik(2)\">Clik Me</button>\n               <div #dynamicContentPlaceHolder></div>"
    }),
    __metadata("design:paramtypes", [core_2.ComponentFactoryResolver])
], dynamicComponent);
exports.dynamicComponent = dynamicComponent;
var Comp1Component = (function () {
    function Comp1Component() {
    }
    return Comp1Component;
}());
Comp1Component = __decorate([
    core_1.Component({
        template: "This is component 1"
    }),
    __metadata("design:paramtypes", [])
], Comp1Component);
exports.Comp1Component = Comp1Component;
var Comp2Component = (function () {
    function Comp2Component() {
    }
    return Comp2Component;
}());
Comp2Component = __decorate([
    core_1.Component({
        template: "This is component 2"
    }),
    __metadata("design:paramtypes", [])
], Comp2Component);
exports.Comp2Component = Comp2Component;
//# sourceMappingURL=customDirective.js.map