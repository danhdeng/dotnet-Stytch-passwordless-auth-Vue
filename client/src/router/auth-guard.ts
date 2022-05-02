import { NavigationGuardNext, RouteLocationNormalized } from 'vue-router';

export const handleAuth = (
  to: RouteLocationNormalized,
  next: NavigationGuardNext
) => {
  console.log('handling authentication');
  next();
};
