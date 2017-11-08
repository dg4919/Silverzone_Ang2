// all filters, services will be register here :)

// filter is our services which inject in decalration part like component
import { stringFilter } from '../Shared/filters';

export const _filters = [   // register filter to use in app globally with HTML page
    stringFilter
];

// services
import { authService } from '../Services/authService';
import { httpService } from '../Shared/httpService';
import { AuthManager } from '../Shared/AuthManager';

export const shared_services = [
    httpService,
    authService,
    AuthManager,
];

// Global Services going here
import { bookFunction } from '../Shared/bookFunctions';
import { bookService } from '../Services/bookService';
import { userService } from '../Services/userService';
import { modalService } from '../Services/modalService';

export const app_services = [
    { provide: 'book_comonFunction', useClass: bookFunction },
    bookService,
    userService,
    modalService
];
