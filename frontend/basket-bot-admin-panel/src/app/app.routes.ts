import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PersonsCardsComponent } from './components/admin/components/persons-cards/persons-cards.component';
import { canActivateGuard } from './guards/can-activate.guard';
import { canDeactivateGuard } from './guards/can-deactivate.guard';
import { personResolver } from './components/admin/resolvers/person.resolver';
import { PersonsListComponent } from './components/admin/components/persons-list/persons-list.component';
import { PersonEditComponent } from './components/admin/components/person-edit/person-edit.component';

export const routes: Routes = [
    { path: 'login', component: LoginComponent},
    { path: '', redirectTo: '/login', pathMatch: 'full'},
    { 
        path: 'persons-list', 
        canActivate: [canActivateGuard],        
        component: PersonsListComponent },        
    { path: 'person/:id', component: PersonsCardsComponent, resolve: {
            person: personResolver
        } 
    },
    { path: 'person-edit/:id', component: PersonEditComponent, resolve: {
        person: personResolver
        } 
    },    
    { path: 'person', redirectTo: '/persons-list', pathMatch: 'full'},          
    { path: '**', component: NotFoundComponent}
];
