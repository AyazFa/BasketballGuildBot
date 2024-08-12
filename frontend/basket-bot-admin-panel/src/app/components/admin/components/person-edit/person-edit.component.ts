import { Component } from '@angular/core';
import { Person } from '../../Person';
import { first } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-person-edit',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './person-edit.component.html',
  styleUrl: './person-edit.component.scss'
})
export class PersonEditComponent {
  person!: Person;
  editForm!: FormGroup;
  constructor(
    private formBuilder: FormBuilder, 
    private activatedRoute: ActivatedRoute, 
    private router: Router, 
    private personService: PersonService) { }

  ngOnInit() {
    this.activatedRoute.data.subscribe((data) => this.person = data?.['person'])
    if(!this.person.id) {
      alert("Invalid action.")
      this.router.navigate(['persons-list']);
      return;
    }
    this.editForm = this.formBuilder.group({
      id: [],
      name: ['', Validators.required],
      userName: ['', Validators.required],
    });

    this.personService.getPerson(+this.person.id)
      .subscribe( data => {
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    this.personService.updatePerson(this.editForm.value)
      .pipe(first())
      .subscribe(
        () => {
          this.router.navigate(['persons-list']);
        },
        (error: any) => {
          alert(error);
        });
  }
}
