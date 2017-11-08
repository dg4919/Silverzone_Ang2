import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Rx';

import { globalConfig } from '../Shared/constants';

@Injectable()           // use to emit Metadata of service
export class authService {

    private apiUrl: string;
    currentUser: any = {};
    isLoggedIn: boolean = false;


    // bcoz here in constructor have another depedency (Http).. so if we inject this service then it will throw error while creating object of this (bookService) class
    // thats wyy we r using @Injectable() to omit the metadata of injected classess (http)
    constructor(private http: Http) {
        this.apiUrl = globalConfig.apiEndPoint + globalConfig.version.Site;
        this.currentUser = JSON.parse(localStorage.getItem('auth_user'));
    }

    Login(model: any) {
        let url = `${this.apiUrl}/Account/Login`;

        return this.http
            .post(url, model)         // search : params is predefined
            .map((res: Response) => {
                var data = res.json();

                if (data.result === 'ok')
                    this.setUser(data)

               return data.result;
            })
            .catch((error: any) => Observable.throw(error.toString() || 'Server error'));
    }

    setUser(userInfo: any) {

        // directly mereg new object into userInfo.user
        Object.assign(userInfo.user, { token: userInfo.token.access_token });

        this.currentUser = userInfo.user;
        this.isLoggedIn = true;

        // local storage store user info in browser & when ever user clear history then it will also removed
        //localStorage.setItem('auth_token', userInfo.token.access_token);
        localStorage.setItem('auth_user', userInfo.user);
    }

}