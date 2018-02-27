import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { CookieService } from 'ngx-cookie-service';

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';

import { ErrorService } from './error.service';

import { LoginViewModel } from '../ViewModels/loginViewModel';
import { RegisterViewModel } from '../ViewModels/registerViewModel';

@Injectable()
export class AccountService extends ErrorService {
    public static isLoggedIn: boolean = false;
    public static isAdmin: boolean = null;

    constructor(private http: Http, private cookie: CookieService) {
        super();
    }

    public login(data: LoginViewModel) {
        return this.http.post('api/account/login', data)
            .map(res => {
                AccountService.isLoggedIn = true;
                AccountService.isAdmin = <boolean>res.json();
                this.cookie.deleteAll();
                this.cookie.set("isLoggedIn", String(AccountService.isLoggedIn), 100, "path");
                this.cookie.set("isAdmin", String(AccountService.isAdmin), 100, "path");
                return true;
            })
            .catch(this.handleError);
    }

    public register(data: RegisterViewModel) {
        return this.http.post('api/account/register', data)
            .map(res => true)
            .catch(this.handleError);
    }

    public logout() {
        this.http.get('api/account/logout').subscribe();
        AccountService.isAdmin = null;
        AccountService.isLoggedIn = false;        
        this.cookie.delete("isLoggedIn");
        this.cookie.delete("isAdmin");
        this.cookie.deleteAll();
    }
}
