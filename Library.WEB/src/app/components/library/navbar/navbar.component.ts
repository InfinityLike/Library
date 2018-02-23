import { Component, OnInit } from '@angular/core';

import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'navbar',
    templateUrl: './navbar.component.html',
})
export class NavbarComponent implements OnInit {
    constructor() { }

    public isLoggedIn: boolean;

    ngOnInit() {
        this.isLoggedIn = AccountService.isLoggedIn;
    }
}
