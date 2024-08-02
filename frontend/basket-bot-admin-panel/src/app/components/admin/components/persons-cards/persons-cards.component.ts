import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Observable } from 'rxjs';
import { Person } from '../../Person';
import { AsyncPipe } from '@angular/common';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-persons-cards',
  standalone: true,
  imports: [RouterModule, AsyncPipe],
  templateUrl: './persons-cards.component.html',
  styleUrl: './persons-cards.component.scss'
})
export class PersonsCardsComponent implements OnInit {
  id!: number;
  person$!: Observable<Person>

  constructor(private activatedRoute: ActivatedRoute, private personService: PersonService) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params) => this.id = params?.['id']);
    this.person$ = this.personService.getPerson(this.id);
  }
}
