import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, Response, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Rx';
import { cacheable, cacheablee, setCacheKey } from './caching';

import { authService } from '../Services/authService';


@Injectable()           // use to emit Metadata of service
export class httpService {

    // bcoz here in constructor have another depedency (Http).. so if we inject this service then it will throw error while creating object of this (bookService) class =>  Can't resolve all parameters for bookService
    // thats wyy we r using @Injectable() to omit the metadata of injected classess (http)
    constructor(private http: Http,
        private authSvc: authService) { }

    Get(url: string,
        params?: URLSearchParams): Observable<Response> {  // Observable<Response> is a return type of fx (optional)

        return this.http
            .get(url, this.getHeader(params))
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.toString() || 'Server error'));
    }

    GetCache(url: string,
        params?: URLSearchParams) {     // params? => ? use to make optional param

        return cacheablee(
            this.http
                .get(url, this.getHeader(params)),
            setCacheKey(url, params)
        )
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.toString() || 'Server error'));
    }

    Post(url: string,
        model?: any): Observable<Response> {

        return this.http
            .post(url, this.getHeader())
            .map((res: Response) => res.json())
            .catch((error: any) => Observable.throw(error.toString() || 'Server error'));
    }


    private getHeader(params?: URLSearchParams): RequestOptions {
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        headers.append('content-Type', 'application/json');

        if (this.authSvc.isLoggedIn)
            headers.append('Authorization', 'Bearer ' + this.authSvc.currentUser.token);

        if (params)
            return new RequestOptions({
                headers: headers,
                search: params
            });
        else
            return new RequestOptions({ headers: headers });
    }

}
