import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

import { GetBrochureViewModel } from '../ViewModels/brochure/getBrochureViewModel';
import { PostBrochureViewModel } from '../ViewModels/brochure/postBrochureViewModel';

@Injectable()
export class BrochureService {
    constructor(private http: HttpClient) { }

    public getBrochures(): Observable<GetBrochureViewModel> {
        return this.http.get('api/brochure').map((response) => {
            return <GetBrochureViewModel>response;
        });;
    }

    public getCoverType(): Observable<string[]> {
        return this.http.get('api/coverType').map((response) => {
            return <string[]>response;
        });;
    }

    public save(data: PostBrochureViewModel, isNew?: boolean): Observable<boolean> {
        if (isNew) {
            return this.http.post('api/brochure', data)
                .map(x => x as boolean);
        }
        if (!isNew) {
            return this.http.put('api/brochure/' + data.id, data)
                .map(x => x as boolean);
        }
    }

    public remove(id): Observable<boolean> {
        return this.http.delete('api/brochure/' + id)
            .map(x => x as boolean);
    }
}
