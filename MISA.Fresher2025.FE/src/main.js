import './assets/css/reset.css';
import './assets/css/icon.css';
import './assets/css/common.css';
import "@fontsource-variable/inter"; // Defaults to wght axis
import "@fontsource-variable/inter/wght.css"; // Specify axis
import "@fontsource-variable/inter/wght-italic.css"; // Specify axis and style

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App)

app.use(router)

app.mount('#app')
