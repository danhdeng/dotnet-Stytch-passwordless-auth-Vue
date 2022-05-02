import { createApp } from 'vue';
import App from './App.vue';
import { store } from './store/store';
import { router } from './router';
const vm = createApp(App).use(router).use(store).mount('#app');

export default vm;
