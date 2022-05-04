import { createApp } from 'vue';
import App from './App.vue';
import { store } from './store/store';
import router from './router';
import './main.css';
const vm = createApp(App).use(router).use(store).mount('#app');

export default vm;
