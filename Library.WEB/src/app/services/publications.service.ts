import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { PublicationsViewModel } from '../ViewModels/publicationsViewModel';


@Injectable()
export class PublicationsService {
    constructor(private http: HttpClient) { }

    public getPublications(): Observable<PublicationsViewModel[]> {
        return this.http.get('api/publications').map((response) => {
            return <PublicationsViewModel[]>response;
        });;
    }
}
