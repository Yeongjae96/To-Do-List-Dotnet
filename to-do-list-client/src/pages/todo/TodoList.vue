<template>
  <y-card>
    <template v-slot:title>
      {{ name }} 
    </template>
    <template v-slot:content>
      <div class="">
        알림줄 &lt;구현예정&gt;
      </div>
      <div class="todo__insert">
        <y-input 
          type="text" 
          width="100%" 
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
          />
        </template>
        <template
          v-else
        >
          <y-empty-list
            message="항목이 존재하지 않습니다."
          />
        </template>
      </ul>
    </template>
    <template v-slot:tail>
      각종 아이콘 메뉴
    </template>
  </y-card>
</template>

<script>
import YInput from '@/components/YInput'
import YButton from '@/components/YButton'
import YCard from '@/components/YCard'
import TodoItem from './TodoItem'
import YEmptyList from '@/components/YEmptyList'

export default {
  name: 'todo-list',
  components: {
    YInput,
    YButton,
    YCard,
    TodoItem,
    YEmptyList,
  },
  // alternativeUrl: 'todo/todos',
  data() {
    return {
      name: 'TODO-LIST',
      inputValue: '',
      todoList: [],
    };
  },
  created() {
    this.init();
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
        regDate: this.$Date.getToday(),
      });
      this.inputValue = '';
    },
    deleteTodo(id) {
      this.todoList = this.$_.filter(this.todoList, todo => todo.id!==id);
    },
    onEnterEvent() {
      console.log('엔터입력 되었어요!');
    },
    onClickEvent() {
      console.log('버튼이 클릭됐어요');
    },
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';
  .todo__insert {
    @include flexRow;
    & > *:not(:last-child) {
      margin-right: 20px;
    }
    
  }
</style>