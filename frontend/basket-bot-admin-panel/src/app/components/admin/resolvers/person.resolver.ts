import { ResolveFn, Router } from '@angular/router';
import { Person } from '../Person';
import { PersonService } from '../services/person.service';
import { inject } from '@angular/core';
import { catchError, EMPTY } from 'rxjs';

export const personResolver: ResolveFn<Person> = (route, state) => {
  return inject(PersonService).getPerson(route.params?.['id']).pipe(
    catchError( () => {
      inject(Router).navigate(['person'])
      return EMPTY
    })
  );
};
