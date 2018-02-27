import { Injectable } from '@angular/core';
import { Response, Headers, RequestOptions } from '@angular/http';
import { HttpClient } from "@angular/common/http";
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

    constructor(private http: HttpClient, private cookie: CookieService) {
        super();
    }

    public login(data: LoginViewModel): Observable<boolean> {
        return this.http.post('api/account/login', data)
            .map(res => {
                AccountService.isLoggedIn = true;
                AccountService.isAdmin = <boolean>res;
                this.cookie.deleteAll();
                this.cookie.set("isLoggedIn", String(AccountService.isLoggedIn), 100, "path");
                this.cookie.set("isAdmin", String(AccountService.isAdmin), 100, "path");
                return true;
            })
            .catch(this.handleError);
    }

    public register(data: RegisterViewModel): Observable<boolean> {
        return this.http.post('api/account/register', data)
            .map(x => x as boolean)
            .catch(this.handleError);
    }

    public logout(): Observable<boolean> {
        this.http.get('api/account/logout').subscribe();
        AccountService.isAdmin = null;
        AccountService.isLoggedIn = false;        
        this.cookie.delete("isLoggedIn");
        this.cookie.delete("isAdmin");
        this.cookie.deleteAll();
        return new Observable<boolean>();
    }
}
