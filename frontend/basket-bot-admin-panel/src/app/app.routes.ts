import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PersonsComponent } from './components/admin/components/persons/persons.component';
import { PersonsCardsComponent } from './components/admin/components/persons-cards/persons-cards.component';
import { canActivateGuard } from './guards/can-activate.guard';
import { canDeactivateGuard } from './guards/can-deactivate.guard';
import { personResolver } from './components/admin/resolvers/person.resolver';

export const routes: Routes = [
    { path: 'login', component: LoginComponent},
    { path: '', redirectTo: '/login', pathMatch: 'full'},
    { 
        path: 'persons', 
        canActivate: [canActivateGuard],
        component: PersonsComponent 
    },
    { path: 'person/:id', component: PersonsCardsComponent, resolve: {
        person: personResolver
    } },
    { path: 'person', redirectTo: '/persons', pathMatch: 'full'},      
    { path: '**', component: NotFoundComponent}
];
