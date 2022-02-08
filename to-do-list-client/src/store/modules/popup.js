const isDuplicatePopup = (popup) =>
  state.list.some((item) => popup.id === item.id);

const state = {
  loading: false,
  list: [],
};

const actions = {};

const mutations = {
  MUT_LOADING(state, payload) {
    state.loading = Boolean(payload);
  },
  MUT_POPUP_LIST(state, payload) {
    if (!(payload && Array.isArray(payload))) return;
    const filteredPayload = payload.filter((item) =>
      state.list.every((_item) => item.id !== _item.id)
    );
    state.list = filteredPayload;
  },
  MUT_POPUP_PUSH(state, payload) {
    if (isDuplicatePopup(payload)) return;
    state.list.push(payload);
  },
  MUT_POPUP_REMOVE(state, payload) {
    console.log("before", state.list);
    console.log(payload);
    state.list = state.list.filter((popup) => popup.id !== payload.id);
    console.log("after", state.list);
  },
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
