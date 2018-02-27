import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { GetAuthorViewModel } from '../../../ViewModels/author/getAuthorViewModel';
import { PostAuthorViewModel } from '../../../ViewModels/author/postAuthorViewModel';

import { AuthorService } from '../../../services/author.service';
import { AccountService } from '../../../services/account.service';
import { GetAuthorViewItem } from '../../../viewModels/author/getAuthorViewItem';

@Component({
    selector: 'author',
    templateUrl: './author.component.html'
})
export class AuthorComponent implements OnInit {
    public authors: GetAuthorViewModel;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private authorService: AuthorService) {
        this.authors = new GetAuthorViewModel();
        this.authors.authors = new Array<GetAuthorViewItem>();
    }

    ngOnInit(): void {
        this.loadAuthorData();
    }

    public onStateChange(state: State) {
        this.gridState = state;
    }

    public addHandler({ sender }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: 0, disabled: true }, Validators.required),
            'name': new FormControl('', Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);

        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
        });

        this.editedRowIndex = rowIndex;

        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const author: PostAuthorViewModel = formGroup.getRawValue();
        this.authorService.save(author, isNew).subscribe(data => {
            this.loadAuthorData();
        });
        sender.closeRow(rowIndex);
    }

    public removeHandler({ dataItem }) {
        this.authorService.remove(dataItem.id).subscribe(data => {
            this.loadAuthorData();
        });
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private loadAuthorData() {
        this.authorService.getAuthors().subscribe(
            (data: GetAuthorViewModel) => {
                this.authors = data;
            }
        );
    }
}
