import { createStore, useStore as us } from "vuex";
import modules from "./modules";
import getters from "./getters";
import VuexPersistence from "vuex-persist";
import _ from 'lodash'


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

export function useStore(namespace) {
  const internalStore = us();
  const result = {};

  return {
    get state() {
      return internalStore.state[namespace]
    },
    dispatch: (key, payload) => internalStore.dispatch(`${namespace}/${key}`, payload),
    commit: (key, payload) => internalStore.commit(`${namespace}/${key}`, payload)
  }
}