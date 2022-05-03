import { createStore } from 'vuex';

export const store = createStore({
  state: {
    emails: [],
  },
  mutations: {
    setEmails(state, emails) {
      state.emails = emails;
    },
  },
});
