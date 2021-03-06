import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/operator/map';

import { GetMagazineViewModel } from '../ViewModels/magazine/getMagazineViewModel';
import { PostMagazineViewModel } from '../ViewModels/magazine/postMagazineViewModel';

@Injectable()
export class MagazineService {
    constructor(private http: HttpClient) {
    }

    public getMagazines(): Observable<GetMagazineViewModel> {
        return this.http.get('api/magazine').map((response) => {
            return <GetMagazineViewModel>response;
        });;
    }

    public save(data: PostMagazineViewModel, isNew?: boolean): Observable<boolean> {
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
