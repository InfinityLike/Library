import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CookieService } from 'ngx-cookie-service';

import { routing } from './app.routing';

//COMPONENTS
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';

import { AccountModule } from './components/account/account.module';
import { LibraryModule } from './components/library/library.module';

import { AccountService } from './services/account.service';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent        
    ],
    imports: [
        routing,
        BrowserModule,
        BrowserAnimationsModule,
        HttpModule,
        JsonpModule,
        AccountModule,
        LibraryModule
    ],
    providers: [
        AccountService,
        CookieService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
