import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { map, Observable } from 'rxjs';
import { Person } from '../../Person';
import { AsyncPipe } from '@angular/common';

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
  person!: Person

  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.person$ = this.activatedRoute.data.pipe(map((data) => data?.['person']))
    this.activatedRoute.data.subscribe((data) => this.person = data?.['person'])
  }

  editPerson(person$: Observable<Person>): void {
    this.router.navigate([`person-edit/${this.person.id}`]);
  };  
}
