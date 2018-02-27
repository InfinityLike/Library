import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { AuthorViewModel } from '../ViewModels/authorViewModel';

@Injectable()
export class AuthorService {
    constructor(private http: Http) { }

    public getAuthors(): Observable<AuthorViewModel[]> {
        return this.http.get('api/author').map((response) => {
            return <AuthorViewModel[]>response.json();
        });;
    }

    public save(data: AuthorViewModel, isNew?: boolean) {
        if (isNew) {
            return this.http.post('api/author', data)
                .map(data => data);
        }
        if (!isNew) {
            return this.http.put('api/author/' + data.id, data)
                .map(data => data);
        }
    }

    public remove(id) {
        return this.http.delete('api/author/' + id)
            .map(data => data);
    }
}
