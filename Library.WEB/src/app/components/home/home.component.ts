import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AccountService } from '../../services/account.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    constructor(private router: Router) { }

    ngOnInit() {
        if (AccountService.isLoggedIn == true) {
            this.router.navigate(['/library']);
        }
    }
}
