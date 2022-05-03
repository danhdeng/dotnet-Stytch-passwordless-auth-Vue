import { NavigationGuardNext, RouteLocationNormalized } from 'vue-router';
import router from '../router';
import { store } from '../store/store';

export const handleAuth = async (
  to: RouteLocationNormalized,
  next: NavigationGuardNext
) => {
  console.log('handling authentication');

  if (to.query.sessionToken) {
    console.log('Found session token', to.query.sessionToken);
    localStorage.sessionToken('sessionToken', to.query.sessionToken);
    await router.replace({ query: undefined });
  }
  const sessionToken = localStorage.getItem('sessionToken') || null;

  console.log('token from localStorage is ', sessionToken);

  //if the route we are receiving requires auth, make an API req to validate the token
  if (to.matched.some((route) => route.meta.requiresAuth)) {
    console.log('Matched a route requires authentication');

    //try to validate token if it exists, otherwise, redirect a user back to login page.

    if (sessionToken) {
      const response = await fetch('http://localhost:8080/verfiyToken', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ token: sessionToken }),
      });

      if (!response.ok) {
        localStorage.removeItem('sessionToken');
        console.error('Error verifying login');
        next('/login');
        return;
      }
      // we have an OK response, set the user emails
      let result = await response.json();
      let userEmails = result.emails;
      store.commit('setEmails', userEmails);
    } else {
      next('/login');
      return;
    }
  } else if (to.matched.some((route) => route.name === 'login')) {
    console.log('Matched login route');
    if (sessionToken) {
      const response = await fetch('http://localhost:8080/verfiyToken', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ token: sessionToken }),
      });
      if (response.ok) {
        next('/');
        return;
      }
    }
  }
  next();
};
