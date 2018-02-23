import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { RootComponent } from './root/root.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'account', component: RootComponent,

        children: [
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ]
    },
]);
