import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'account', loadChildren: 'app/account/account.module#AccountModule' },
    { path: 'library', loadChildren: 'app/library/library.module#LibraryModule' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
