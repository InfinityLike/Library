import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { BookViewModel } from '../ViewModels/bookViewModel';


@Injectable()
export class BookService {
    constructor(private http: Http) { }

    public getBooks(): Observable<BookViewModel[]> {
        return this.http.get('api/book').map((response) => {
            return <BookViewModel[]>response.json();
        });;
    }

    public save(data: BookViewModel, isNew?: boolean) {
        if (isNew) {
            return this.http.post('api/book', data)
                .map(data => data);
        }
        if (!isNew) {
            return this.http.put('api/book/' + data.id, data)
                .map(data => data);
        }
    }

    public remove(id) {
        return this.http.delete('api/book/' + id)
            .map(data => data);
    }
}
