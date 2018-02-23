import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { PublicationsViewModel } from '../ViewModels/publicationsViewModel';


@Injectable()
export class PublicationsService {
    constructor(private http: Http) { }

    public getPublications(): Observable<PublicationsViewModel[]> {
        return this.http.get('api/publications').map((response) => {
            return <PublicationsViewModel[]>response.json();
        });;
    }
}
