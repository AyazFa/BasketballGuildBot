import { CanActivateFn, CanDeactivateFn, Router } from '@angular/router';
import { AuthorizationService } from '../services/authorization.service';
import { inject } from '@angular/core';


export const canActivateGuard: CanActivateFn = (route, state) => {
  const isLoggedIn = inject(AuthorizationService).isLoggedIn();
  const router = inject(Router);
  if (!isLoggedIn){
    router.navigate(['login']);
    return false;
  }

  return true;
};

