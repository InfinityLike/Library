import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { State, process } from '@progress/kendo-data-query';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { BookViewModel } from '../../../ViewModels/bookViewModel';
import { PublisherViewModel } from '../../../ViewModels/publisherViewModel';
import { AuthorViewModel } from '../../../ViewModels/authorViewModel';

import { BookService } from '../../../services/book.service';
import { PublisherService } from '../../../services/publisher.service';
import { AccountService } from '../../../services/account.service';
import { AuthorService } from '../../../services/author.service';

@Component({
    selector: 'book',
    templateUrl: './book.component.html'
})
export class BookComponent implements OnInit {
    public books: Array<BookViewModel>;
    public publishersData: Array<PublisherViewModel>;
    public authorsData: Array<AuthorViewModel>
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };
    public formGroup: FormGroup;
    private editedRowIndex: number;

    public isAdmin = AccountService.isAdmin;
    public isLoggedIn = AccountService.isLoggedIn;

    constructor(private bookService: BookService,
        private publisherService: PublisherService,
        private authorService: AuthorService) { }

    ngOnInit() {
        this.loadBookData();
        this.loadPublisherData();
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
            'authors': new FormControl('', Validators.required),
            'dateOfPublishing': new FormControl(new Date(2000, 10, 10, 10), Validators.required),
            'publishers': new FormControl('', Validators.required),
        });

        sender.addRow(this.formGroup);
    }

    public editHandler({ sender, rowIndex, dataItem }) {
        this.closeEditor(sender);
        this.formGroup = new FormGroup({
            'id': new FormControl({ value: dataItem.id, disabled: true }, Validators.required),
            'name': new FormControl(dataItem.name, Validators.required),
            'authors': new FormControl(dataItem.authors, Validators.required),
            'dateOfPublishing': new FormControl(new Date(dataItem.dateOfPublishing), Validators.required),
            'publishers': new FormControl(dataItem.publishers, Validators.required),
        });

        this.editedRowIndex = rowIndex;
        sender.editRow(rowIndex, this.formGroup);
    }

    public cancelHandler({ sender, rowIndex }) {
        this.closeEditor(sender, rowIndex);
    }

    public saveHandler({ sender, rowIndex, formGroup, isNew }) {
        const book: BookViewModel = formGroup.getRawValue();

        var oldDate = new Date(book.dateOfPublishing);
        var date = new Date(oldDate.getFullYear(), oldDate.getMonth(), oldDate.getDate(), 12, 0, 0);
        book.dateOfPublishing = date;

        this.bookService.save(book, isNew).subscribe(data => {
            this.loadBookData();
        });
        sender.closeRow(rowIndex);
    }

    public removeHandler({ dataItem }) {
        this.bookService.remove(dataItem.id).subscribe(data => {
            this.loadBookData();
        });
    }

    private closeEditor(grid, rowIndex = this.editedRowIndex) {
        grid.closeRow(rowIndex);
        this.editedRowIndex = undefined;
        this.formGroup = undefined;
    }

    private loadBookData() {
        this.bookService.getBooks().subscribe(
            (data: Array<BookViewModel>) => {
                this.books = data;
            }
        );
    }

    private loadPublisherData() {
        this.publisherService.getPublishers().subscribe(
            (data: Array<PublisherViewModel>) => {
                this.publishersData = data;
            }
        );
    }

    private loadAuthorData() {
        this.authorService.getAuthors().subscribe(
            (data: Array<AuthorViewModel>) => {
                this.authorsData = data;
            }
        );
    }
}
