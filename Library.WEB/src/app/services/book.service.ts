import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { GetBookViewModel } from '../ViewModels/book/getBookViewModel';
import { PostBookViewModel } from '../ViewModels/book/postBookViewModel';

@Injectable()
export class BookService {
    constructor(private http: HttpClient) { }

    public getBooks(): Observable<GetBookViewModel> {
        return this.http.get('api/book').map((response) => {
            return <GetBookViewModel>response;
        });;
    }

    public save(data: PostBookViewModel, isNew?: boolean): Observable<boolean> {
        if (isNew) {
            return this.http.post('api/book', data)
                .map(x => x as boolean);
        }
        if (!isNew) {
            return this.http.put('api/book/' + data.id, data)
                .map(x => x as boolean);
        }
    }

    public remove(id): Observable<boolean> {
        return this.http.delete('api/book/' + id)
            .map(x => x as boolean);
    }
}
