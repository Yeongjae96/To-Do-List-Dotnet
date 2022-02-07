const state = {
  loading: false,
};

const actions = {};

const mutations = {
  MUT_LOADING(state, payload) {
    state.loading = Boolean(payload);
  },
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
