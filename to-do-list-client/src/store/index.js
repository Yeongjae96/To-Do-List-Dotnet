import { createStore } from "vuex";
import modules from "./modules";
import getters from "./getters";
import VuexPersistence from "vuex-persist";

const vuexLocal = new VuexPersistence({
  key: "STORAGE_KEY",
  storage: window.localStorage,
  reducer: (state) => ({
    todoStore: {
      searchParam: state.todoStore.searchParam,
    },
  }),
});

export default createStore({
  getters,
  modules,
  plugins: [vuexLocal.plugin],
});
