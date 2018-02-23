import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { PublicationsViewModel } from '../../../ViewModels/publicationsViewModel';

import { PublicationsService } from '../../../services/publications.service';

@Component({
    selector: 'publications',
    templateUrl: './publications.component.html'
})
export class PublicationsComponent implements OnInit {
    public publications: Array<PublicationsViewModel>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    constructor(private publicationsService: PublicationsService) { }

    ngOnInit(): void {

        this.publicationsService.getPublications().subscribe(
            (data: Array<PublicationsViewModel>) => {
                this.publications = data;
            }
        );
    }
}
