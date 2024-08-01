import { CanDeactivateFn } from '@angular/router';

export const canDeactivateGuard: CanDeactivateFn<unknown> = (component, currentRoute, currentState, nextState) => {
  if (confirm('Do you really want to logout?')){
    localStorage.removeItem('token')
    return true
  }

  return false
};
