import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthorizationService } from '../../../../services/authorization.service';

@Component({
  selector: 'app-persons',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './persons.component.html',
  styleUrl: './persons.component.scss'
})
export class PersonsComponent {

  constructor(private authorizationService: AuthorizationService) {

  }

  logout() {
    this.authorizationService.logout();
  }
}
