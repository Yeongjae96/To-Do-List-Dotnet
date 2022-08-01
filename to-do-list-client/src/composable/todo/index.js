import { getTodoList, insertTodo, updateCompleted, updateTodo, deleteTodo } from "@/api/TodoApi";
import { ref, computed, onMounted, watch, provide, inject } from "vue";
import { TODO } from "@/utils/Const";
import { getHeaderData } from "@/composable/common/YDataTable";

export function initTodoListPageData() {
  // pagination
  const pagination = ref(null);
  provide(TODO.provideKey.pagination, pagination);

  // searchParam
  const searchParam = ref({
    pageNo: 1,
    pageSize: 10,
    pageNumPerOnce: 10,
    searchKeyword: "",
    sortCondition: [
      { propertyName: "Completed", direction: 0 },
      { propertyName: "RegDate", direction: 0 },
    ],
  });
  watch(
    () => searchParam.value.pageSize,
    () => {
      if (!pagination.value) {
        console.debug(pagination);
        return;
      }
      pagination.value.pageSize = searchParam.value.pageSize;
    }
  );
  provide(TODO.provideKey.searchParam, searchParam);

  // modalOption
  const modalOption = ref({
    visible: false,
    param: {},
    width: "90%",
    height: "90%",
    title: "",
    path: "",
  });
  const pageSizeOptions = ref([1, 5, 10, 15]);
  const inputValue = ref("");
  const todoList = ref([]);

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
