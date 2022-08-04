import { getTodoList, insertTodo, updateCompleted, updateTodo, deleteTodo } from "@/api/TodoApi";
import { ref, computed, onMounted, watch, provide, inject } from "vue";
import { TODO } from "@/utils/Const";
import { getHeaderData } from "@/composable/common/YDataTable";

export function initTodoListPageData() {
  // pagination

  return {
    searchParam,
    modalOption,
    pageSizeOptions,
    pagination,
    inputValue,
    todoList,
  };
}

export function initializeDataTable() {
  const todoHeader = getHeaderData([
    {
      type: "text",
      key: "title",
      text: "제목",
      width: "*",
    },
    {
      type: "icon",
      key: "completed",
      text: "완료여부",
      width: "100px",
      extensionProperties: {
        name: "circle",
      },
      compute: {
        color: (data) => TODO.completedColor[data.completed],
      },
    },
    {
      type: "text",
      key: "tag",
      text: "태그",
      width: "100px",
    },
    {
      type: "date",
      key: "regDate",
      text: "작성일",
      width: "100px",
      editable: false,
    },
    {
      type: "text",
      text: "추가기능",
      width: "100px",
    },
  ]);

  return {
    todoHeader,
  };
}

// export function initializeTodoData() {
//   const todoData = ref(TODO.provideKey.list);
// }
