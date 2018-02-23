import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { BrochureViewModel } from '../ViewModels/brochureViewModel';

@Injectable()
export class BrochureService {
    constructor(private http: Http) { }

    public getBrochures(): Observable<BrochureViewModel[]> {
        return this.http.get('api/brochure').map((response) => {
            return <BrochureViewModel[]>response.json();
        });;
    }

    public getTypeOfCover(): Observable<string[]> {
        return this.http.get('api/typeOfCover').map((response) => {
            return <string[]>response.json();
        });;
    }

    public save(data: any, isNew?: boolean): Observable<any> {
        if (isNew) {
            return this.http.post('api/brochure', data)
                .map(data => data as any);
        }
        if (!isNew) {
            return this.http.put('api/brochure/' + data.id, data)
                .map(data => data as any);
        }
    }

    public remove(id): Observable<any> {
        return this.http.delete('api/brochure/' + id)
            .map(data => data as any);
    }
}
