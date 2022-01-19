import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from "./store";

// fontawesome
import { library } from '@fortawesome/fontawesome-svg-core'
import { faUserSecret } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

// Component
import YIcon from '@/components/YIcon';


library.add(faUserSecret);

const app = createApp(App);

app.use(router);
app.use(store);

app.component('y-icon', YIcon);
app.component('font-awesome-icon', FontAwesomeIcon);

app.mount('#app');
