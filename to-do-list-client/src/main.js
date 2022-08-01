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
import YPagination from "@/components/common/YPagination";
import YSelect from "@/components/common/YSelect";
import YDataTable from "@/components/common/YDataTable";

// Directives
import { inputDebounce, enterDebounce } from "@/directives/debouncer";

library.add(fas);

// Vue App
const app = createApp(App);

// GlobalProperties
app.config.globalProperties.$_ = _;
app.config.globalProperties.$moment = moment;

// Middleware
app.use(utils);
app.use(router);
app.use(store);

// Global Component
app.component("y-icon", YIcon);
app.component("y-button", YButton);
app.component("y-card", YCard);
app.component("y-empty-list", YEmptyList);
app.component("y-input", YInput);
app.component("y-modal", YModal);
app.component("y-pagination", YPagination);
app.component("y-select", YSelect);
app.component("y-data-table", YDataTable);

// Directive
app.directive("input-debounce", inputDebounce);
app.directive("enter-debounce", enterDebounce);

// Mount
app.mount("#app");
