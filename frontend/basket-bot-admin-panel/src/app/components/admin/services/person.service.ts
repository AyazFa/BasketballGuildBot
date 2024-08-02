import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../Person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private httpClient: HttpClient) { }

  getPersonList() {
    return this.httpClient.get<Person[]>('https://localhost:5144/api/adminpanel/persons');
  }

  getPerson(id: number) {
    return this.httpClient.get<Person>(`https://localhost:5144/api/adminpanel/person/${id}`)
  }
}
