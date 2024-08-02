import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthorizationService } from '../../../../services/authorization.service';
import { Observable } from 'rxjs';
import { Person } from '../../Person';
import { PersonService } from '../../services/person.service';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-persons',
  standalone: true,
  imports: [RouterModule, AsyncPipe],
  templateUrl: './persons.component.html',
  styleUrl: './persons.component.scss'
})
export class PersonsComponent {

  personList$!: Observable<Person[]>;

  constructor(private authorizationService: AuthorizationService, private personSerice: PersonService) {
  }

  ngOnInit(): void {
    this.personList$ = this.personSerice.getPersonList();
  }

  logout() {
    this.authorizationService.logout();
  }
}
