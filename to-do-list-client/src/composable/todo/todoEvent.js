import { insertTodo, updateCompleted, deleteTodo as deleteApi } from "@/api/TodoApi";
import moment from "moment";
import _ from "lodash";

export async function updateTodoCompleted(todo) {
  if (_.isEmpty(todo)) return;

  await updateCompleted(todo);
}

export async function deleteTodo(todo) {
  if (_.isEmpty(todo)) return;

  await deleteApi(todo);
}

export async function simpleCreateTodo(value) {
  if (_.isEmpty(value)) return;

  await insertTodo({
    title: value,
  });
  // reloadTodoList();
}
