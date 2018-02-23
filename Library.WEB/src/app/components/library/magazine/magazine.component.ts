import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Observable } from 'rxjs/Observable';

import { State, process } from '@progress/kendo-data-query';

import { MagazineViewModel } from '../../../ViewModels/magazineViewModel';

import { MagazineService } from '../../../services/magazine.service';
import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'magazine',
    templateUrl: './magazine.component.html'
})
export class MagazineComponent implements OnInit {
    private data: Array<MagazineViewModel> = [];
    public magazines: Array<MagazineViewModel>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private magazineService: MagazineService) { }

    ngOnInit(): void {
        this.loadMagazineData();
    }

    public onStateChange(state: State) {
        this.gridState = state;

        //this.service.query(state);

        //this.editService.read();
    }

    public addHandler({ sender }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: 0, disabled: true }, Validators.required),
            'name': new FormControl('', Validators.required),
            'number': new FormControl(0, Validators.required),
            'yearOfPublishing': new FormControl(0, Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'number': new FormControl(dataItem.number, Validators.required),
            'yearOfPublishing': new FormControl(dataItem.yearOfPublishing, Validators.required),
        });

        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const magazine: MagazineViewModel = formGroup.getRawValue();
        this.magazineService.save(magazine, isNew).subscribe(data => {
            this.loadMagazineData();
        });
        sender.closeRow(rowIndex);
    }

    public removeHandler({ dataItem }) {
        this.magazineService.remove(dataItem.id).subscribe(data => {
            this.loadMagazineData();
        });
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private loadMagazineData() {
        this.magazineService.getMagazines().subscribe(
            (data: Array<MagazineViewModel>) => {
                this.magazines = data;
            }
        );
    }
}
