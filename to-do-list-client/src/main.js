import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import utils from "./plugins/utils";

// fontawesome
import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";

//library
import _ from "lodash";
import moment from "moment";

// Component
import YIcon from "@/components/common/YIcon";
import YButton from "@/components/common/YButton";
import YCard from "@/components/common/YCard";
import YEmptyList from "@/components/common/YEmptyList";
import YInput from "@/components/common/YInput";
import YModal from "@/components/common/YModal";

// Directives
import { inputDebounce, enterDebounce } from "@/directives/debouncer";

library.add(fas);

const app = createApp(App);

app.config.globalProperties.$_ = _;
app.config.globalProperties.$moment = moment;

app.use(utils);
app.use(router);
app.use(store);

app.component("y-icon", YIcon);
app.component("y-button", YButton);
app.component("y-card", YCard);
app.component("y-empty-list", YEmptyList);
app.component("y-input", YInput);
app.component("y-modal", YModal);

app.directive("input-debounce", inputDebounce);
app.directive("enter-debounce", enterDebounce);

app.mount("#app");
