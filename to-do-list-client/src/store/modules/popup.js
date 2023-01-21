import _ from 'lodash'

const state = {
  loading: false,
  list: [],
  currentID: 0, // 추후 GUID 값으로 변경
};

const isDuplicatePopup = (popup) => state.list.some((item) => popup.id === item.id);
const createPopupID = () => state.currentID++;


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
    console.log('isDuplicatePopup', isDuplicatePopup(payload))
    console.log('state.list', state.list)
    if (isDuplicatePopup(payload)) return;
    console.log(payload, state.list);
    state.list.push(payload);
  },
  MUT_POPUP_REMOVE(state, payload) {
    console.log("before", state.list);
    console.log(payload.id);
    // state.list = state.list.filter((popup) => popup.id !== payload.id);
    state.list = _.remove(state.list, {
      id: payload.id,
    });
    console.log("after", state.list);
  },
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
