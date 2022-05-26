<template>
  <div class="todo__wrapper">
    <y-card>
      <template #title>
        {{ name }}
      </template>
      <template #content>
        <div class="todo__alert">
          알림줄 &lt;구현예정 &gt;
          <div class="right">
            <y-button
              width="10%"
              height="30px"
              borderColor="#EE5058"
              backgroundColor="white"
              text="Reload"
              @click="reloadTodoList"
            />
          </div>
        </div>
        <div class="todo__insert">
          <y-input
            v-enter-debounce="100"
            type="text"
            width="85%"
            height="30px"
            borderColor="gray"
            v-model="inputValue"
            autoComplete="입력해주세요"
            @enter="createTodo"
          />
          <y-button
            width="10%"
            height="30px"
            borderColor="black"
            backgroundColor="#EE5058"
            text="추가"
            @click="(e) => createTodo(inputValue)"
            color="white"
          />
        </div>
        <ul class="todo__list">
          <template v-if="todoList.length > 0">
            <todo-item
              v-for="(todo, idx) in todoList"
              :key="todo.id"
              :no="idx"
              v-bind="todo"
              @delete="deleteTodo"
              @update="openUpdateTodo"
              @click="onClick"
            />
          </template>
          <y-empty-list v-else :message="emptyMessage" />
        </ul>
      </template>
      <template #tail> 각종 아이콘 메뉴 </template>
    </y-card>
    <y-modal :="modalOption" @close="() => (modalOption.visible = false)">
      <template #default>
        <component :key="currentCom.component" :is="currentCom.component" />
      </template>
    </y-modal>
  </div>
</template>
<script>
import TodoItem from "@/components/todo/TodoItem";
import {
  getTodoList,
  insertTodo,
  updateTodo as updateTodoApi,
  deleteTodo as deleteTodoApi,
} from "@/api/TodoApi";
export default {
  name: "todo-list",
  components: {
    TodoItem,
  },
  // alternativeUrl: 'todo/todos',
  data() {
    return {
      name: "todo-list",
      inputValue: "",
      todoList: [],
      modalOption: {
        visible: false,
        param: {},
        width: "90%",
        height: "90%",
        title: "",
        path: "",
      },
      emptyMessage: '항목이 존재하지 않습니다.',
    };
  },
  created() {},
  mounted() {
    this.init().catch((error) => console.error(error));
  },
  methods: {
    async init() {
      try {
        await this.reloadTodoList();
      } catch(e) {
        console.log(e);
        if (e.message.startsWith('Network Error')) {
          this.emptyMessage = '통신 오류로 인해 목록을 불러오지 못했습니다. 잠시 후에 다시 시도 바랍니다.' 
        }
      }
    },
    async createTodo(title) {
      if (this.$_.isEmpty(title)) return;

      const response = await insertTodo({
        title: this.inputValue,
        completed: false,
      });

      if (response.status !== 200) {
        console.error("ERROR!", response);
        return;
      }

      this.reloadTodoList();
      // success
      // this.todoList.push({
      //   id: `{t:${this.todoList.length}}`,
      //   title: ,
      //   priority: 0,
      //   flag: "N",
      //   regDate: this.$date.getToday(),
      // });
      this.inputValue = "";
    },
    async updateTodo(todo) {
      await updateTodoApi(todo);
      this.reloadTodoList();
    },
    async deleteTodo(id) {
      // this.todoList = this.$_.filter(this.todoList, (todo) => todo.id !== id);
      await deleteTodoApi({ id });
      this.reloadTodoList();
    },
    async reloadTodoList() {
      this.todoList = await getTodoList();
    },
    openUpdateTodo(id) {
      this.modalOption.title = "할 일 수정";
      this.modalOption.path = "/todo/TodoUpdate";
      this.modalOption.param.id = id;
      this.modalOption.visible = true;
    },
    onClick({ tagName, id }) {
      const eventMap = {
        completed: () => {
          const todo = this.selectTodoListById(id);
          // todo.priority = (todo.priority + 1) % 3;
          todo.completed = !todo.completed;
          this.updateTodo(todo);
        },
      };
      const func = eventMap[tagName] || Function(`console.log("${tagName}")`);
      func.call();
    },
    selectTodoListById(id) {
      return this.$_.filter(this.todoList, (item) => item.id === id)[0];
    },
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

.right {
  position: absolute;
  right: 10px;
}

.todo__wrapper {
  width: 100%;
  height: 100%;
}

.todo__insert {
  @include flexRow;
  & > *:not(:last-child) {
    margin-right: 20px;
  }
}
.todo__alert {
  @include flexRow(stretch, center);
  min-height: 30px;
}

.todo__list {
  flex: 1;
}
</style>
