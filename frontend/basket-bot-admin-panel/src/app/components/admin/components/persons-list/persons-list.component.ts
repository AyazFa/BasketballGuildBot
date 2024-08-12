import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../../Person';
import { AuthorizationService } from '../../../../services/authorization.service';
import { PersonService } from '../../services/person.service';
import { AsyncPipe } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-persons-list',
  standalone: true,
  imports: [RouterModule, AsyncPipe],
  templateUrl: './persons-list.component.html',
  styleUrl: './persons-list.component.scss'
})
export class PersonsListComponent {
  personList$!: Observable<Person[]>;

  constructor(
    private authorizationService: AuthorizationService, 
    private personSerice: PersonService
  ) {
  }

  ngOnInit(): void {
    this.personList$ = this.personSerice.getPersonList();
  }

  logout() {
    this.authorizationService.logout();
  }
}
