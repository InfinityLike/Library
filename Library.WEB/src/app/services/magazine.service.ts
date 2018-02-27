import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/map';

import { MagazineViewModel } from '../ViewModels/magazineViewModel';

@Injectable()
export class MagazineService {
    constructor(private http: HttpClient) {
    }

    public getMagazines(): Observable<MagazineViewModel[]> {
        return this.http.get('api/magazine').map((response) => {
            return <MagazineViewModel[]>response;
        });;
    }

    public save(data: MagazineViewModel, isNew?: boolean): Observable<boolean> {
        if (isNew) {
            return this.http.post('api/magazine', data)
                .map(x => x as boolean);
        }
        if (!isNew) {
            return this.http.put('api/magazine/' + data.id, data)
                .map(x => x as boolean);
        }
    }

    public remove(id): Observable<boolean> {
        return this.http.delete('api/magazine/' + id)
            .map(x => x as boolean);
    }
}
