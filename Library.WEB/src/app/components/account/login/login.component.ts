import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { LoginViewModel } from '../../../ViewModels/account/loginViewModel';

import { AccountService } from '../../../services/account.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

    private subscription: Subscription;

    brandNew: boolean;
    errors: string;
    isRequesting: boolean;
    submitted: boolean = false;
    loginModel: LoginViewModel = { email: '', password: '' };

    constructor(private accountService: AccountService, private router: Router, private activatedRoute: ActivatedRoute) {
    }

    ngOnInit() {
        this.accountService.logout();
        AccountService.isAdmin = null;
        AccountService.isLoggedIn = false;
        
        this.subscription = this.activatedRoute.queryParams.subscribe(
            (param: any) => {
                this.brandNew = param['brandNew'];
                this.loginModel.email = param['email'];
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    login({ value, valid }: { value: LoginViewModel, valid: boolean }) {
        this.submitted = true;
        this.isRequesting = true;
        this.errors = '';
        if (valid) {
            this.accountService.login(value)
                .finally(() => this.isRequesting = false)
                .subscribe(
                result => {
                    if (result) {
                        this.router.navigate(['/library']);
                    }
                },
                error => this.errors = error);
        }
    }
}
