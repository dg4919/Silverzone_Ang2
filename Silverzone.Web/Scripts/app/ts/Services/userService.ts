import { Injectable } from '@angular/core';
import { Http, Response, URLSearchParams, RequestOptions, Headers } from '@angular/http';

import { Observable } from 'rxjs/Rx';

import { httpService } from '../Shared/httpService';
import { globalConfig } from '../Shared/constants';

@Injectable()           // use to emit Metadata of service
export class userService {
    private apiUrl: string;
    private user_api: string;

    constructor(
        private httpSvc: httpService,
        private http: Http) {
        this.apiUrl = globalConfig.apiEndPoint + globalConfig.version.Site;
        this.user_api = globalConfig.apiEndPoint + globalConfig.version.User;
    }
                                           
    getUser_shippingAdress () {
        let url = `${this.apiUrl}/Order/get_shipping_Address_byUserId`;
        return this.httpSvc.Get(url);
    }

    uploadImage(files: FileList) {
        let formData: FormData = new FormData();

        for (var i = 0; i < files.length; i++) {
            formData.append("file", files[i]);
        }

        let header = new Headers();
        //header.append('Content-Type', 'multipart/form-data');
        //header.append('Accept', 'application/json');
        let options = new RequestOptions({ headers: header });

        let url = `${this.user_api}/UserProfile/uploaduserImage`;

        return this.http.post(url, formData, options)
            .map(res => res.json())
            .catch(error => Observable.throw(error));
    }

}