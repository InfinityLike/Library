import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { GetPublisherViewModel } from '../ViewModels/publisher/getPublisherViewModel';
import { PostPublisherViewModel } from '../viewModels/publisher/postPublisherViewModel';

@Injectable()
export class PublisherService {
    constructor(private http: HttpClient) { }

    public getPublishers(): Observable<GetPublisherViewModel> {
        return this.http.get('api/publisher').map((response) => {
            return <GetPublisherViewModel>response;
        });;
    }

    public save(data: PostPublisherViewModel, isNew?: boolean): Observable<boolean> {
        if (isNew) {
            return this.http.post('api/publisher', data)
                .map(x => x as boolean);
        }
        if (!isNew) {
            return this.http.put('api/publisher/' + data.id, data)
                .map(x => x as boolean);
        }
    }

    public remove(id): Observable<boolean> {
        return this.http.delete('api/publisher/' + id)
            .map(x => x as boolean);
    }
}
