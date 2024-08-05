import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { map, Observable } from 'rxjs';
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
    this.person$ = this.activatedRoute.data.pipe(map((data) => data?.['person']))
  }
}
