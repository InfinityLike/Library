import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { AuthorViewModel } from '../ViewModels/authorViewModel';

@Injectable()
export class AuthorService {
    constructor(private http: HttpClient) { }

    public getAuthors(): Observable<AuthorViewModel[]> {
        return this.http.get('api/author').map((response) => {
            return <AuthorViewModel[]>response;
        });;
    }

    public save(data: AuthorViewModel, isNew?: boolean): Observable<boolean> {
        if (isNew) {
            return this.http.post('api/author', data)
                .map(x => x as boolean);
        }
        if (!isNew) {
            return this.http.put('api/author/' + data.id, data)
                .map(x => x as boolean);
        }
    }

    public remove(id): Observable<boolean> {
        return this.http.delete('api/author/' + id)
            .map(x => x as boolean);
    }
}
