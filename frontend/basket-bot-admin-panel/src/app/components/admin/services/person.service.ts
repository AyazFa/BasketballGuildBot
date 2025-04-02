import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../Person';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  constructor(private httpClient: HttpClient) { }

  getPersonList() {
    return this.httpClient.get<Person[]>(`${environment.apiUrl}/adminpanel/persons`);
  }

  getPerson(id: number) {
    return this.httpClient.get<Person>(`${environment.apiUrl}/adminpanel/person/${id}`)
  }

  updatePerson(person: Person) {
    return this.httpClient.put<Person>(`${environment.apiUrl}/api/adminpanel/person/${person.id}`,person);
  }
}
