import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { PublisherViewModel } from '../ViewModels/publisherViewModel';


@Injectable()
export class PublisherService {
    constructor(private http: Http) { }

    public getPublishers(): Observable<PublisherViewModel[]> {
        return this.http.get('api/publisher').map((response) => {
            return <PublisherViewModel[]>response.json();
        });;
    }

    public save(data: PublisherViewModel, isNew?: boolean) {
        if (isNew) {
            return this.http.post('api/publisher', data)
                .map(data => data);
        }
        if (!isNew) {
            return this.http.put('api/publisher/' + data.id, data)
                .map(data => data);
        }
    }

    public remove(id) {
        return this.http.delete('api/publisher/' + id)
            .map(data => data);
    }
}
