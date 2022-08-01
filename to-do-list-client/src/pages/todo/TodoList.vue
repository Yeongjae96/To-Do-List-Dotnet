<template>
  <div class="todo__wrapper">
    <y-card>
      <template #title>
        {{ name }}
      </template>
      <template #content>
        <div class="todo__alert">
          알림줄 &lt;구현예정 &gt;
          <y-select :data="pageSizeOptions" suffix="개" v-model="searchParam.pageSize" @change="onChangePageSize" />
          <div class="right">
            <y-button width="10%" height="30px" borderColor="#EE5058" backgroundColor="white" text="Reload"
              @click="reloadTodoList" />
            <!-- @click="reloadTodoList" -->
          </div>
        </div>
        <div class="todo__insert">
          <y-input v-enter-debounce="100" type="text" width="85%" height="30px" borderColor="gray" v-model="inputValue"
            autoComplete="입력해주세요" @enter="createTodo" />
          <y-button width="10%" height="30px" borderColor="black" backgroundColor="#EE5058" text="추가"
            @click="(e) => createTodo(inputValue)" color="white" />
        </div>
        <ul class="todo__list">
          <y-data-table :header="todoHeader" :data="todoList" />
          <!-- <template v-if="todoList.length > 0">
            <todo-item
              v-for="(todo, idx) in todoList"
              :key="todo.no"
              :id="idx"
              :="todo"
              @delete="deleteTodo"
              @update="updateTodo"
              @detailUpdate="openUpdateTodo"
              @click="onClick"
            />
          </template>
          <y-empty-list v-else :message="emptyMessage" /> -->
        </ul>
      </template>
      <template #tail>
        <todo-footer />
      </template>
    </y-card>
    <y-modal :="modalOption" @close="() => (modalOption.visible = false)">
      <template #default>
        <component :key="currentCom.component" :is="currentCom.component" />
      </template>
    </y-modal>
  </div>
</template>
<script >
import { insertTodo, getTodoList } from "@/api/TodoApi";
import TodoItem from "@/components/todo/TodoItem";
import { ref, provide, watch, onMounted } from 'vue'
import { TODO } from '@/utils/Const'
import TodoFooter from "@/components/todo/TodoFooter";
import YDataTable from "@/components/common/YDataTable.vue";
// import { initTodoListPageData, initializeDataTable } from '@/composable/todo'
// import { onChangePageSize, reloadTodoList, createTodo } from '@/composable/todo/todoEvent'
export default {
  name: "todo-list",
  components: {
    TodoItem,
    TodoFooter,
    YDataTable
  },
  setup(props, context) {
    const name = '할 일 목록'

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

    // const { todoHeader } = initializeDataTable(); // 데이터테이블 헤더 설정
    // const { todoData, reloadTodoList } = initializeTodoData({ searchParam, pagination });

    const todoHeader = ref([
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


    const reloadTodoList = async () => {
      if (searchParam.value == null) throw new Error("Need inject -> [searchParam, pagination]");

      const response = await getTodoList(searchParam.value);
      todoList.value = response.list;
      pagination.value = response.pagination;
    }
    
    const createTodo = async (inputValue) => {
      if (this.$_.isEmpty(inputValue.value)) return;
      await insertTodo({
        title: inputValue.value,
      });
      reloadTodoList();
      inputValue.value = "";
    }

    const onChangePageSize = ({ pageNo }) => {
      reloadTodoList();
    }

    onMounted(() => {
      reloadTodoList();
    });


    return {
      // initializeParam
      name,
      searchParam,
      modalOption,
      pageSizeOptions,
      pagination,
      emptyMessage: '항목이 존재하지 않습니다.',
      inputValue,
      todoList,

      todoHeader,
      reloadTodoList,

      // event
      onChangePageSize,
      createTodo
    };
  },
  // alternativeUrl: 'todo/todos',
  // data() {
  //   return {
  //     name: "todo-list",
  //     inputValue: "",
  //     todoList: [],
  //     searchParam: {
  //       pageNo: 1,
  //       pageSize: 10,
  //       pageNumPerOnce: 10,
  //       searchKeyword: '',
  //       sortCondition: [
  //         { propertyName: 'Completed', direction: 0, },
  //         { propertyName: 'RegDate', direction: 0, },
  //       ], 
  //       data: null
  //     },
  //     modalOption: {
  //       visible: false,
  //       param: {},
  //       width: "90%",
  //       height: "90%",
  //       title: "",
  //       path: "",
  //     },
  //     pageSizeOptions: [
  //       1, 5, 10, 15
  //     ],
  //     pagination: null,
  //     emptyMessage: '항목이 존재하지 않습니다.',
  //   };
  // },
  // created() {},
  // mounted() {
  // },
  // watch: {
  //   "searchParam.pageSize"() {
  //     if (this.pagination && this.pagination.pageSize) {
  //       this.pagination.pageSize = Number(this.searchParam.pageSize);
  //     }
  //   },
  // },
  // methods: {
  //   test(e) {
  //     this.searchParam.pageNo = e;
  //     this.reloadTodoList();
  //   },
  //   async init() {
  //     try {
  //       await this.reloadTodoList();
  //     } catch(e) {
  //       console.error(e);
  //       if (e.message.startsWith('Network Error')) {
  //         this.emptyMessage = '통신 오류로 인해 목록을 불러오지 못했습니다. 잠시 후에 다시 시도 바랍니다.' 
  //       }
  //     }
  //   },
  //   async createTodo(title) {
  //     if (this.$_.isEmpty(title)) return;

  //     await insertTodo({
  //       title: this.inputValue,
  //     });
  //     this.reloadTodoList();
  //     this.inputValue = "";
  //   },
  //   async updateTodo(todo) {
  //     await updateTodoApi(todo);
  //     await this.reloadTodoList();
  //   },
  //   async deleteTodo(no) {
  //     // this.todoList = this.$_.filter(this.todoList, (todo) => todo.no !== no);
  //     await deleteTodoApi({ no });
  //     this.reloadTodoList();
  //   },
  //   async reloadTodoList() {
  //     // 결과값을 보낼때 SearchParam을 보내야한다.
  //     const response = await getTodoList(this.searchParam); 
  //     this.todoList = response.list;
  //     this.pagination = response.pagination;

  //     this.todoList.forEach(item => {
  //       const format = this
  //         .$moment(item.regDate)
  //         .format('YYYY-MM-DD HH:mm:ss');
  //       item.regDate = format;
  //     });
  //   },
  //   onChangePageSize(e) {

  //     // console.debug(this.searchParam.pageSize);
  //   },
  //   openUpdateTodo(no) {
  //     this.modalOption.title = "할 일 수정";
  //     this.modalOption.path = "/todo/TodoUpdate";
  //     this.modalOption.param.no = no;
  //     this.modalOption.visible = true;
  //   },
  //   onClick({ tagName, no }) {
  //     const eventMap = {
  //       completed: () => {
  //         const todo = this.selectTodoListById(no);
  //         todo.completed = !todo.completed;
  //         updateCompleted(todo).then(this.reloadTodoList);
  //       },
  //     };
  //     const func = eventMap[tagName] || Function(`console.log("${tagName}")`);
  //     func.call();
  //   },
  //   selectTodoListById(no) {
  //     return this.$_.filter(this.todoList, (item) => item.no === no)[0];
  //   },
  // },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

.right {
  position: absolute;
  right: 20px;
  top: 2px;
}

.todo__wrapper {
  width: 100%;
  height: 100%;
}

.todo__insert {
  @include flexRow;

  &>*:not(:last-child) {
    margin-right: 10px;
  }
}

.todo__alert {
  @include flexRow(stretch, center);
  position: relative;
  min-height: 30px;
}

.todo__list {
  flex: 1;
}


.todo__insert div {
  outline: 0;
  border-top: 0;
  border-left: 0;
  border-right: 0;
  border-bottom: 1px solid;
  border-color: rgba(190, 190, 190, 0.8);
  padding: 5px 5px 5px 10px;
  margin-left: 2px;
  margin-top: 1px;

  &:focus {
    border: 1px solid;
    border-color: rgb(163, 147, 253);
    margin-left: 0px;
    margin-top: 0px;
  }
}

li[role="dataHeader"] {
  @include flexRow;
}
</style>
