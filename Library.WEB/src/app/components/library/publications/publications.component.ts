import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { GetPublicationsViewModel } from '../../../ViewModels/publications/getPublicationsViewModel';

import { GetPublicationsViewItem } from '../../../viewModels/publications/getPublicationsViewItem';

import { PublicationsService } from '../../../services/publications.service';

@Component({
    selector: 'publications',
    templateUrl: './publications.component.html'
})
export class PublicationsComponent implements OnInit {
    public publications: GetPublicationsViewModel;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    constructor(private publicationsService: PublicationsService) {
        this.publications = new GetPublicationsViewModel();
        this.publications.publications = new Array<GetPublicationsViewItem>();
    }

    ngOnInit(): void {

        this.publicationsService.getPublications().subscribe(
            (data: GetPublicationsViewModel) => {
                this.publications = data;
            }
        );
    }
}
