import { generateMutationNames } from "../store-types";
import { getTodoList } from "@/api/TodoApi";
import moment from "moment";
import { getToday } from "@/utils/Date";

const state = {
  todoList: [],
  searchParam: {
    pageNo: 1,
    pageSize: 10,
    pageNumPerOnce: 10,
    sortCondition: [
      { propertyName: "Completed", direction: 0 },
      { propertyName: "RegDate", direction: 0 },
    ],
  },
  pagination: null,
};

const actions = {
  async ACT_GET_TODO_LIST({ commit, state }) {
    const response = await getTodoList(state.searchParam);

    const todoRegDateFormat = (value) => {
      return moment(value).format("YYYY-MM-DD") === getToday() ? "HH:mm:ss" : "MM월 DD일 HH:mm:ss";
    };

    // 후처리
    response.list.forEach((item) => {
      // 등록일
      item.regDate = moment(item.regDate).format(todoRegDateFormat(item.regDate));
    });

    commit("MUT_TODO_LIST", response.list);
    commit("MUT_PAGINATION", response.pagination);
  },
};

const mutations = {
  MUT_PAGINATION(state, payload) {
    state.pagination = payload;
  },
  MUT_SEARCH_PARAM(state, payload) {
    state.searchParam = payload;
  },
  MUT_ADD_SEARCH_PARAM_SORT(state, payload) {
    if (!(state.searchParam && state.searchParam.sortCondition)) {
      state.searchParam.sortCondition = [];
    }
    state.searchParam.sortCondition.push(payload);
  },
  MUT_TODO_LIST(state, payload) {
    state.todoList = payload;
  },
  MUT_SEARCH_PARAM_PAGE_NO(state, payload) {
    state.searchParam.pageNo = Number(payload);
  },
};

export const mapMutations = generateMutationNames(mutations);
export const mapActions = generateMutationNames(actions);

export default {
  namespaced: true,
  state,
  mutations,
  actions,
};
