import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AccountService } from './services/account.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private accountService: AccountService, private router: Router) { }

    canActivate() {
        if (!AccountService.isLoggedIn) {
            this.router.navigate(['/account/login']);
            return false;
        }

        return true;
    }
}
