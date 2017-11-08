//  this path contains Partial components / Directives

import {
    Component,
    Input,
    Inject,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';

import { FormGroup, FormControl } from '@angular/forms';
import { ValidationService } from '../Services/validationService';
import { Router } from '@angular/router';

import { bookSearch_model } from '../Model/book';

import { bookFunction } from '../Shared/bookFunctions';
import { bookService } from '../Services/bookService';

import { stringFilter } from '../Shared/filters';

@Component({
    // dont use ':' = (book:info) > coz its bind only right part.. So use [book-info OR book_info]
    selector: 'book_info',
    templateUrl: '/templates/customDirective_template/bookList.html',
    providers: [stringFilter],  // to inject and use filter with class use provider otherwise declare it in (providers) of app.module to use globly
    inputs: ['book']            // contains bookinfo used in template
})

export class bindBooks_directiveComponent {

    // register only dependency here :)
    constructor(
        @Inject('book_comonFunction') private rsc: bookFunction,    // rsc is like a rootscope variable
        private router: Router,
        private strFilter: stringFilter
    ) { }

    addtoCart(bookInfo: any) {
        this.rsc.add_bookInCart(bookInfo, 1);
    }

    onSelect(bookInfo: any) {
        this.router.navigate(['/Book/Info', bookInfo.BookId, this.strFilter.transform(bookInfo.book_title)]);
    }

}

@Component({
    selector: 'bundle',
    templateUrl: '/templates/customDirective_template/bundleList.html',
    inputs: ['bundles']
})

export class bindBundle_directiveComponent {
    bundleQty: Array<number> = [];

    constructor(@Inject('book_comonFunction') private rsc: bookFunction) { }

    onkeyPress($event: any) {
        $event.value = this.rsc.checkCart_Value(parseInt($event.value));
    }

    changeQty($event: any,
        is_AddQty: boolean) {
        $event.value = this.rsc.get_newQty($event.value, is_AddQty);
    }

    addCombo_toCart(
        bookBundleInfo: any,
        qty: number) {
        this.rsc.add_bundleInCart(
            bookBundleInfo,
            parseInt(qty.toString()));
    }

}


@Component({
    selector: 'bookSearch',
    templateUrl: '/templates/Partials/book_search.html'    
})
export class bookSearch_directiveComponent implements OnInit {
    private classList: any;
    private subjectList: any;
    private categoryList: any;

    private srchModel = new bookSearch_model();

    @Output()
    onSearchBooks: EventEmitter<bookSearch_model> = new EventEmitter();

    constructor(private _bookService: bookService) { }

    ngOnInit() {
        this.get_AllClass();
        this.get_AllCategorys();
    }

    get_AllClass() {
        this._bookService.getAll_class()
            .subscribe((data: any) => {
                this.classList = data.result
                this.get_Subjects(data.result[0].Id);
            },
            (error: any) => console.log(error));
    }

    get_Subjects(classId: number) {
        this._bookService.get_subject_byClassId(classId)
            .subscribe((data: any) => this.subjectList = data.result,
            (error: any) => console.log(error));
    }

    get_AllCategorys() {
        this._bookService.get_bookCategorys()
            .subscribe((data: any) => this.categoryList = data.result,
            (error: any) => console.log(error));
    }

    srchBooks() {
        this.onSearchBooks.emit(this.srchModel);
    }

}


@Component({
    selector: 'cartAction',
    template: ` <button class="btn btn-default btn-guests btn-guests-minus btn-sm" 
                        style="font-size: 7px !important;"
                        (click)="changeQty(currentIndex, cartQty, true)">
                    <span class="fa-stack">
                        <i class="fa fa-circle-thin fa-stack-2x"></i>
                        <i class="fa fa-plus fa-stack-1x"></i>
                    </span>
                </button>
                <input type="text" style="width: 60px;text-align: center;" maxlength="2"
                       [value]="cartQty"
                       (keyup)="onkeyPress(currentIndex, $event)">
                <button class="btn btn-default btn-guests btn-guests-plus btn-sm" 
                        style="font-size: 7px !important;"
                        (click)="changeQty(currentIndex, cartQty, false)">
                    <span class="fa-stack">
                        <i class="fa fa-circle-thin fa-stack-2x"></i>
                        <i class="fa fa-minus fa-stack-1x"></i>
                    </span>
                </button>`,
    inputs: ['cartQty', 'currentIndex']
})
export class cartAction_directiveComponent {

    constructor(@Inject('book_comonFunction') private rsc: bookFunction) { }

    onkeyPress(index: number,
        $event: any) {

        var newValu = this.rsc.checkCart_Value(parseInt($event.target.value));
        $event.target.value = newValu;

        this.changeQty(
            index,
            newValu,
            true,
            true);
    }

    changeQty(
        index: number,
        Qty: number,
        is_AddQty: boolean,
        key_event: boolean) {

        // bcoz fx returning value in string (thats wy convert its value)
        Qty = parseInt(Qty.toString());

        this.rsc.update_CartQty(
            index,
            key_event ? Qty : this.rsc.get_newQty(Qty, is_AddQty)
        );
    }

}

@Component({
    selector: 'control-messages',
    template: `<span class="text-danger"
                     *ngIf="errorMessage !== null">
                 {{errorMessage}}
               </span>`
})
export class ControlMessages {
    @Input() control: FormControl;
    
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
    errorMessage: string = '';

    ngOnChanges(changes: any): void {
        this.errorMessage = '';

        let errors: any = changes;
        console.log(errors);

        for (let propertyName in this.control.errors) {
            if (this.control.errors.hasOwnProperty(propertyName) && this.control.touched) {
                this.errorMessage = ValidationService.getValidatorErrorMessage(propertyName, this.control.errors[propertyName]);
            }
        }
    }
}

import {
    HostListener, Directive, ElementRef, Renderer, AfterViewInit,
    ViewContainerRef,
    ViewChild, ComponentFactoryResolver
} from '@angular/core';

// Directive decorator
@Directive({ selector: '[myHidden]' })
// Directive class
export class HiddenDirective {
    constructor(
        private el: ElementRef,
        private renderer: Renderer) {
        // Use renderer to render the element with styles
        //renderer.setElementStyle(el.nativeElement, 'display', 'none');
    }

    @HostListener('mouseenter') onmouseover() {
        this.el.nativeElement.style.backgroundColor = 'yellow';
        //this.renderer.setElementStyle(this.el.nativeElement, 'background-color', '#1f1');
    }

    @HostListener('mouseleave') onmouseleave() {
        this.renderer.setElementStyle(this.el.nativeElement, 'background-color', '#ddd');
    }
}


@Component({
    selector: 'dynamic-component',
    template: `<button (click)="onClik(1)">Clik Me</button>
               <button (click)="onClik(2)">Clik Me</button>
               <div #dynamicContentPlaceHolder></div>`
})
export class dynamicComponent {
    @ViewChild('dynamicContentPlaceHolder', { read: ViewContainerRef })
    protected injectComp: ViewContainerRef;

    constructor(private _componentFactoryResolver: ComponentFactoryResolver) {
    }

    onClik(val: any) {
        if (val === 1) {
            const componentFactory = this._componentFactoryResolver.resolveComponentFactory(Comp1Component);
            const componentRef = this.injectComp.createComponent(componentFactory);
        }
        else {
            const componentFactory = this._componentFactoryResolver.resolveComponentFactory(Comp2Component);
            const componentRef = this.injectComp.createComponent(componentFactory);
        }
    }

}

@Component({
    template: `This is component 1`
})
export class Comp1Component {
}

@Component({
    template: `This is component 2`
})
export class Comp2Component {
}
