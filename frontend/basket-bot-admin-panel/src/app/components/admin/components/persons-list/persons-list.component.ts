import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../../Person';
import { AuthorizationService } from '../../../../services/authorization.service';
import { PersonService } from '../../services/person.service';
import { Router, RouterModule } from '@angular/router';
import { AsyncPipe } from '@angular/common';

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
    private personSerice: PersonService,
    private router: Router,
  ) {
  }

  ngOnInit(): void {
    this.personList$ = this.personSerice.getPersonList();
  }

  editPerson(user: Person): void {
    this.router.navigate(['edit-person']);
  };

  logout() {
    this.authorizationService.logout();
  }
}
