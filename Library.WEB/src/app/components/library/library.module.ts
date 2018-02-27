import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//KENDO MODULE
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { GridModule } from '@progress/kendo-angular-grid'
import { DropDownListModule } from '@progress/kendo-angular-dropdowns';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';

import { routing } from './library.routing';

//COMPONENTS
import { RootComponent } from './root/root.component';
import { NavbarComponent } from './navbar/navbar.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BookComponent } from './book/book.component';
import { BrochureComponent } from './brochure/brochure.component';
import { MagazineComponent } from './magazine/magazine.component';
import { PublicationsComponent } from './publications/publications.component';
import { PublisherComponent } from './publisher/publisher.component';
import { AuthorComponent } from './author/author.component';

//SERVICES
import { BookService } from '../../services/book.service';
import { BrochureService } from '../../services/brochure.service';
import { MagazineService } from '../../services/magazine.service';
import { PublicationsService } from '../../services/publications.service';
import { PublisherService } from '../../services/publisher.service';
import { AccountService } from '../../services/account.service';
import { AuthorService } from '../../services/author.service';

import { AuthGuard } from '../../auth.guard';

@NgModule({
    imports: [
        CommonModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        JsonpModule,
        routing,
        GridModule,
        DropDownsModule,
        DropDownListModule,
        DateInputsModule
    ],
    declarations: [
        RootComponent,
        NavbarComponent,
        DashboardComponent,
        BookComponent,
        BrochureComponent,
        MagazineComponent,
        PublicationsComponent,
        PublisherComponent,
        AuthorComponent
    ],
    exports: [],
    providers: [
        AuthGuard,
        BookService,
        BrochureService,
        MagazineService,
        PublicationsService,
        PublisherService,
        AccountService,
        AuthorService
    ]
})
export class LibraryModule { }
