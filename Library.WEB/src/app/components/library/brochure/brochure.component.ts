import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { GetBrochureViewModel } from '../../../ViewModels//brochure/getBrochureViewModel';
import { PostBrochureViewModel } from '../../../ViewModels//brochure/postBrochureViewModel';

import { GetBrochureViewItem } from '../../../viewModels/brochure/getBrochureViewItem';

import { BrochureService } from '../../../services/brochure.service';
import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'brochure',
    templateUrl: './brochure.component.html'
})
export class BrochureComponent implements OnInit {
    public brochures: GetBrochureViewModel;
    public coverType: Array<string>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private brochureService: BrochureService) {
        this.brochures = new GetBrochureViewModel();
        this.brochures.brochures = new Array<GetBrochureViewItem>();
    }

    ngOnInit(): void {
        this.loadBrochureData();
        this.loadCoverTypeData();
    }

    public onStateChange(state: State) {
        this.gridState = state;
    }

    public addHandler({ sender }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: 0, disabled: true }, Validators.required),
            'name': new FormControl('', Validators.required),
            'numberOfPages': new FormControl(0, Validators.required),
            'coverType': new FormControl('', Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'numberOfPages': new FormControl(dataItem.numberOfPages, Validators.required),
            'coverType': new FormControl(dataItem.coverType, Validators.required),
        });

        this.editedRowIndex = rowIndex;
        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const brochure: PostBrochureViewModel = formGroup.getRawValue();
        this.brochureService.save(brochure, isNew).subscribe(data => {
            this.loadBrochureData();
        });
        sender.closeRow(rowIndex);
    }

    public removeHandler({ dataItem }) {
        this.brochureService.remove(dataItem.id).subscribe(data => {
            this.loadBrochureData();
        });
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private loadBrochureData() {
        this.brochureService.getBrochures().subscribe(
            (data: GetBrochureViewModel) => {
                this.brochures = data;
            }
        );
    }

    private loadCoverTypeData() {
        this.brochureService.getCoverType().subscribe(
            (data: Array<string>) => {
                this.coverType = data;
            }
        );
    }
}
