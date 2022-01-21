import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from "./store";
import lodash from './plugins/lodash';
import moment from './plugins/moment';

// fontawesome
import { library } from '@fortawesome/fontawesome-svg-core'
import { fas } from '@fortawesome/free-solid-svg-icons'

// Component
import YIcon from '@/components/YIcon';

library.add(fas);

const app = createApp(App);

// library
// lodash
app.use(lodash);
// moment
app.use(moment);

app.use(router);
app.use(store);

app.component('y-icon', YIcon);

app.mount('#app');
