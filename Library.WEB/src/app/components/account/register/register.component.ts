import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RegisterViewModel } from '../../../ViewModels/registerViewModel';

import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;

    constructor(private accountService: AccountService, private router: Router) {
    }

    ngOnInit() {
        this.accountService.logout();
        AccountService.isAdmin = null;
        AccountService.isLoggedIn = false;
    }

    register({ value, valid }: { value: RegisterViewModel, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (!valid) {
            return;
        }
        this.accountService.register(value)
            .finally(() => this.isRequesting = false)
            .subscribe(
            result => {
                if (result) {
                    this.router.navigate(['/account/login'], { queryParams: { brandNew: true, email: value.email } });
                }
            },
            errors => this.errors = errors);
    }  
}
