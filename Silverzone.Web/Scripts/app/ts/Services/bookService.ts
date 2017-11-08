import { Injectable } from '@angular/core';
import { URLSearchParams } from '@angular/http';

import { httpService } from '../Shared/httpService';
import { globalConfig } from '../Shared/constants';

@Injectable()
export class bookService {

    private apiUrl: string;

    constructor(private httpSvc: httpService) {
        this.apiUrl = globalConfig.apiEndPoint + globalConfig.version.Site;
    }

    // by default public
    get_bookDetail(book_Id: number) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('bookId', book_Id.toString());

        let url = `${this.apiUrl}/Book/get_bookDetail_byId`;

        return this.httpSvc.GetCache(url, params);
    }

    get_bookBundleDetail(bundleId: number) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('bundleId', bundleId.toString());

        let url = `${this.apiUrl}/Book/get_bookBundleDetail_byId`;

        return this.httpSvc.GetCache(url, params);
    }

    searchBooks(model: any) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('classId', model.classId);
        params.set('subjectId', model.subjectId);
        if (model.cateogysId.length)
            params.set('book_categoriesId', model.cateogysId);

        let url = `${this.apiUrl}/Book/searchBooks`;

        // save the result for 1st time & use it again & again
        return this.httpSvc.GetCache(url, params);
    }
    
    getbook_bundles(class_id: number) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('classId', class_id.toString());

        let url = `${this.apiUrl}/Book/getbook_bundles`;
        return this.httpSvc.GetCache(url, params);
    }

    getAll_class() {
        let url = `${this.apiUrl}/Book/getAllClass`;
        return this.httpSvc.GetCache(url);
    }

    get_subject_byClassId(_classId: number) {
        let params: URLSearchParams = new URLSearchParams();
        params.set('classId', _classId.toString());

        let url = `${this.apiUrl}/Subject/Get_subjects_ByclassId`;
        return this.httpSvc.GetCache(url, params);
    }

    get_bookCategorys() {
        let url = `${this.apiUrl}/Category/category_List`;
        return this.httpSvc.GetCache(url);
    }

}