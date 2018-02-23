import { Component, OnInit } from '@angular/core';

import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'root',
  templateUrl: './root.component.html',
})
export class RootComponent implements OnInit  {
    constructor() { }

    public isAdmin: boolean

    ngOnInit() {
        this.isAdmin = AccountService.isAdmin;
    }
}
