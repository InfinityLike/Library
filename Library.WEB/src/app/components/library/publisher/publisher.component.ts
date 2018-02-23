import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { PublisherViewModel } from '../../../ViewModels/publisherViewModel';

import { PublisherService } from '../../../services/publisher.service';
import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'publisher',
    templateUrl: './publisher.component.html'
})
export class PublisherComponent implements OnInit {
    public publishers: Array<PublisherViewModel>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private publisherService: PublisherService) { }

    ngOnInit(): void {
        this.loadPublisherData();
    }

    public onStateChange(state: State) {
        this.gridState = state;
    }

    public addHandler({ sender }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: 0, disabled: true }, Validators.required),
            'name': new FormControl('', Validators.required),
            'address': new FormControl('', Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'address': new FormControl(dataItem.address, Validators.required),
        });

        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const publisher: PublisherViewModel = formGroup.getRawValue();
        this.publisherService.save(publisher, isNew).subscribe(data => {
            this.loadPublisherData();
        });
        sender.closeRow(rowIndex);
    }

    public removeHandler({ dataItem }) {
        this.publisherService.remove(dataItem.id).subscribe(data => {
            this.loadPublisherData();
        });
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private loadPublisherData() {
        this.publisherService.getPublishers().subscribe(
            (data: Array<PublisherViewModel>) => {
                this.publishers = data;
            }
        );
    }
}
