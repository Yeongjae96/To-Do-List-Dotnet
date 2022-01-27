<template>
  <div class="todo__wrapper">
    <y-card>
      <template #title>
        {{ name }} 
      </template>
      <template #content>
        <div class="todo__alert">
          알림줄 &lt;구현예정 &gt;
        </div>
        <div class="todo__insert">
          <y-input 
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
          <template 
            v-if="todoList.length > 0" 
          >
            <todo-item 
              v-for="todo in todoList" 
              :key="todo.id"
              v-bind="todo"
              @delete="deleteTodo"
              @update="openUpdateTodo"
              @click="onClick"
            />
          </template>
          <y-empty-list v-else
            message="항목이 존재하지 않습니다."
          />
        </ul>
      </template>
      <template #tail>
        각종 아이콘 메뉴
      </template>
    </y-card>
    <y-modal
      :width="modalOption.width"
      :height="modalOption.height"
      :title="currentCom.title"
      @close="() => option.visible = false"
    >
      <component :key="currentCom.component" :is="currentCom.component" />
    </y-modal>
  </div>
</template>
<script>
import TodoItem from '@/components/todo/TodoItem'
import TodoUpdate from './TodoUpdate'

export default {
  name: 'todo-list',
  components: {
    TodoItem,
    TodoUpdate
  },
  // alternativeUrl: 'todo/todos',
  data() {
    return {
      name: 'todo-list',
      inputValue: '',
      todoList: [],
      option: {
        visible: false,
        height: '500px',
        param: {},
      },
      currentCom: {
        title: '',
        component: '',
      },
      modalOption: {
        width: '90%',
        height: '90%',
      }
    };
  },
  created() {
    console.log(this.$const);
    console.log(this);

    this.init().catch(error => console.error(error));
  },
  mounted() {
  },
  methods: {
    async init() {
      this.todoList = await this.getTodoList();
    },
    async getTodoList() {
      // TODO: API 통신으로 변경해야 함 
      return [
        { id: String(1), subject: '테스트1', detail: '1자세한 내용은 Detail에서....', priority: 0, flag: 'N', regDate: '2021-10-13'},
        { id: String(2), subject: '테스트2', detail: '2자세한 내용은 Detail에서....', priority: 1, flag: 'T', regDate: '2021-10-21'},
        { id: String(3), subject: '테스트3', detail: '3자세한 내용은 Detail에서....', priority: 2, flag: 'D', regDate: '2021-11-01'},
        { id: String(4), subject: '테스트4', detail: '4자세한 내용은 Detail에서....', priority: 0, flag: 'N', regDate: '2021-11-15'},
      ]
    },
    createTodo(title){
        if (this.$_.isEmpty(title)) return;
      this.todoList.push({
        id: `{t:${this.todoList.length}}`,
        subject: title, 
        priority: 0,
        flag: 'N',
        regDate: this.$date.getToday(),
      });
      this.inputValue = '';
    },
    deleteTodo(id) {
      this.todoList = this.$_.filter(this.todoList, todo => todo.id!==id);
    },
    openUpdateTodo(id) {
      this.currentCom = { title: '할 일 수정', component: 'todo-update' } ;
      this.option.param.id = id;
      this.option.visible = true;
    },
    onClick({tagName, id}) {
      const eventMap = {
        'priority': () => {
          const todo = this.selectTodoListById(id);
          todo.priority = (todo.priority + 1) % 3; 
        },
      }
      const func = eventMap[tagName] || Function(`console.log("${tagName}")`);
      func.call(); 
    },
    selectTodoListById(id) {
      return this.$_.filter(this.todoList, item => item.id === id)[0];
    }
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  
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