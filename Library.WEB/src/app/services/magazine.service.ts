import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/map';

import { MagazineViewModel } from '../ViewModels/magazineViewModel';

@Injectable()
export class MagazineService {
    constructor(private http: Http) {
    }

    public getMagazines(): Observable<MagazineViewModel[]> {
        return this.http.get('api/magazine').map((response) => {
            return <MagazineViewModel[]>response.json();
        });;
    }

    public save(data: MagazineViewModel, isNew?: boolean) {
        if (isNew) {
            return this.http.post('api/magazine', data)
                .map(data => data);
        }
        if (!isNew) {
            return this.http.put('api/magazine/' + data.id, data)
                .map(data => data);
        }
    }

    public remove(id) {
        return this.http.delete('api/magazine/' + id)
            .map(data => data);
    }
}
