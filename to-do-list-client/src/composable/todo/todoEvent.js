import { insertTodo, getTodoList } from "@/api/TodoApi";
import moment from "moment";
import _ from "lodash";
import { getToday } from "@/utils/Date";

// const todoRegDateFormat = (value) => {
//   return moment(value).format("YYYY-MM-DD") === getToday() ? "HH:mm:ss" : "MM월 DD일 HH:mm:ss";
// };

// export async function reloadTodoList({ searchParam, pagination, todoList }) {
//   const response = await getTodoList(searchParam.value);
//   // 후처리
//   response.list.forEach((item) => {
//     // 등록일
//     item.regDate = moment(item.regDate).format(todoRegDateFormat(item.regDate));
//   });

//   todoList.value = response.list;
//   pagination.value = response.pagination;
// }

// export async function reloadTodoList() {
//   store.dispatch("todoStore/ACT_GET_TODO_LIST");
// }

export async function simpleCreateTodo(value) {
  if (_.isEmpty(value)) return;

  await insertTodo({
    title: value,
  });
  // reloadTodoList();
}
