import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { BrochureViewModel } from '../../../ViewModels/brochureViewModel';

import { BrochureService } from '../../../services/brochure.service';
import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'brochure',
    templateUrl: './brochure.component.html'
})
export class BrochureComponent implements OnInit {
    public brochures: Array<BrochureViewModel>;
    public typesOfCover: Array<string>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private brochureService: BrochureService) { }

    ngOnInit(): void {
        this.loadBrochureData();
        this.loadTypeOfCoverData();
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
            'typeOfCover': new FormControl('', Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'numberOfPages': new FormControl(dataItem.numberOfPages, Validators.required),
            'typeOfCover': new FormControl(dataItem.typeOfCover, Validators.required),
        });

        this.editedRowIndex = rowIndex;
        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const brochure: BrochureViewModel = formGroup.getRawValue();
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
            (data: Array<BrochureViewModel>) => {
                this.brochures = data;
            }
        );
    }

    private loadTypeOfCoverData() {
        this.brochureService.getTypeOfCover().subscribe(
            (data: Array<string>) => {
                this.typesOfCover = data;
            }
        );
    }
}
