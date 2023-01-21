import { generateMutationNames } from "../store-types";
import { getTodoList } from "@/api/TodoApi";
import _ from 'lodash';
import moment from "moment";
import { getToday } from "@/utils/Date";
const getDefaultSearchParam = () => {
  return {
    pageNo: 1,
    pageSize: 10,
    pageNumPerOnce: 10,
    sortCondition: [
      { propertyName: "completed", direction: 0 },
      { propertyName: "regDate", direction: 0 },
      { propertyName: "completedDate", direction: 1 },
    ],
  }
}

const state = {
  todoList: [],
  searchParam: getDefaultSearchParam(),
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
      item.completedDate = item.completedDate ? moment(item.completedDate).format(todoRegDateFormat(item.completedDate)) : '';
    });

    commit("MUT_TODO_LIST", response.list);
    commit("MUT_PAGINATION", response.pagination);
  },
};

const getters = {
  // get 
}

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
  MUT_CHANGE_SORT(state, payload) {
    if (!(state.searchParam && state.searchParam.sortCondition)) return;
    
    const sortCondition = state.searchParam.sortCondition;
    const sortConditionIdx = _.findIndex(sortCondition, (sort) => sort.propertyName === payload.propertyName);
    if (sortConditionIdx > -1) {
      sortCondition.splice(sortConditionIdx, 1);
    }
    sortCondition.unshift(payload);

    
  },
  MUT_TODO_LIST(state, payload) {
    state.todoList = payload;
  },
  MUT_SEARCH_PARAM_PAGE_NO(state, payload) {
    state.searchParam.pageNo = Number(payload);
  },
  MUT_CLEAR_SEARCH_PARAM(state) {
    state.searchParam = getDefaultSearchParam();
  }
};

export const mapMutations = generateMutationNames(mutations);
export const mapActions = generateMutationNames(actions);

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters,
};