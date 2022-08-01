import { insertTodo, getTodoList } from "@/api/TodoApi";
import { TODO } from "@/utils/Const";
import { inject } from "vue";

export async function reloadTodoList() {
  const searchParam = inject(TODO.provideKey.searchParam);
  const pagination = inject(TODO.provideKey.pagination);
  const todoData = inject(TODO.provideKey.list);

  if (searchParam == null || pagination == null) throw new Error("Need inject -> [searchParam, pagination]");

  const response = await getTodoList(searchParam.value);
  todoData.value = response.list;
  pagination.value = response.pagination;
}

export async function createTodo(inputValue) {
  if (this.$_.isEmpty(inputValue.value)) return;

  await insertTodo({
    title: inputValue.value,
  });
  reloadTodoList();
  inputValue.value = "";
}

export function onChangePageSize({ pageNo }) {
  // const searchParam = inject(TODO.provideKey.searchParam);
  // searchParam.value.pageNo = pageNo;
  reloadTodoList();
}
