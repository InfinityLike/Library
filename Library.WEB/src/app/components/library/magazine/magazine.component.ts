import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { Observable } from 'rxjs/Observable';

import { State, process } from '@progress/kendo-data-query';

import { GetMagazineViewModel } from '../../../ViewModels/magazine/getMagazineViewModel';
import { PostMagazineViewModel } from '../../../ViewModels/magazine/postMagazineViewModel';

import { GetMagazineViewItem } from '../../../viewModels/magazine/getMagazineViewItem';

import { MagazineService } from '../../../services/magazine.service';
import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'magazine',
    templateUrl: './magazine.component.html'
})
export class MagazineComponent implements OnInit {
    public magazines: GetMagazineViewModel;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private magazineService: MagazineService) {
        this.magazines = new GetMagazineViewModel();
        this.magazines.magazines = new Array<GetMagazineViewItem>();
    }

    ngOnInit(): void {
        this.loadMagazineData();
    }

    public onStateChange(state: State) {
        this.gridState = state;
    }

    public addHandler({ sender }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: 0, disabled: true }, Validators.required),
            'name': new FormControl('', Validators.required),
            'number': new FormControl(0, Validators.required),
            'dateOfPublishing': new FormControl(new Date(2000, 10, 10, 10), Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'number': new FormControl(dataItem.number, Validators.required),
            'dateOfPublishing': new FormControl(new Date(dataItem.dateOfPublishing), Validators.required),
        });

        this.editedRowIndex = rowIndex;
        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const magazine: PostMagazineViewModel = formGroup.getRawValue();

        var oldDate = new Date(magazine.dateOfPublishing);
        var date = new Date(oldDate.getFullYear(), oldDate.getMonth(), oldDate.getDate(), 12, 0, 0);
        magazine.dateOfPublishing = date;

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
            (data: GetMagazineViewModel) => {
                this.magazines = data;
            }
        );
    }
}
