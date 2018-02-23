import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AccountService } from '../../services/account.service';

import { routing } from './account.routing';

import { RootComponent } from './root/root.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        routing,
    ],
    declarations: [
        RootComponent,
        NavbarComponent,
        LoginComponent,
        RegisterComponent
    ],
    providers: [
        AccountService
    ]
})
export class AccountModule { }
