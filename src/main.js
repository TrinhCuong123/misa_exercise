import './assets/css/MsCommons.css'
import './assets/css/MsIconLink.css'
import './assets/css/MsIcon.css'
import './assets/css/MsStyle.css'
import './assets/css/MsVariables.css'
import './assets/css/MsControls.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App)

app.use(router)

app.mount('#app')
