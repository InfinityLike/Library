import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { GetPublicationsViewModel } from '../ViewModels/publications/getPublicationsViewModel';


@Injectable()
export class PublicationsService {
    constructor(private http: HttpClient) { }

    public getPublications(): Observable<GetPublicationsViewModel> {
        return this.http.get('api/publications').map((response) => {
            return <GetPublicationsViewModel>response;
        });;
    }
}
