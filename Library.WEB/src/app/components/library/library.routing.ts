import { ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AuthGuard } from '../../auth.guard';
import { RootComponent } from './root/root.component';
import { BookComponent } from './book/book.component';
import { BrochureComponent } from './brochure/brochure.component';
import { MagazineComponent } from './magazine/magazine.component';
import { PublicationsComponent } from './publications/publications.component';
import { PublisherComponent } from './publisher/publisher.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
    {
        path: 'library', component: RootComponent, canActivate: [AuthGuard],

        children: [
            { path: 'book', component: BookComponent },
            { path: 'brochure', component: BrochureComponent },
            { path: 'magazine', component: MagazineComponent },
            { path: 'publications', component: PublicationsComponent },
            { path: 'publisher', component: PublisherComponent }
        ]
    }
]);
