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
          width="80%" 
          height="30px" 
          borderColor="gray" 
          v-model="inputValue" 
          autoComplete="입력해주세요"
          @enter="(e) => createTodo(e)"
        />
        <y-button
          width="50px"
          height="30px"
          borderColor="black"
          backgroundColor="#EE5058"
          text="추가"
          @click="onClickEvent"
        />
      </div>
      <ul class="todo__list">
        <todo-item 
          v-for="todo in todoList" 
          :key="todo.id"
          v-bind="todo" 
        />
        <!-- <li class="todo__item" v-for="todo in todoList" :key="todo.id">
          <div class="todo__subject">
            {{ todo.subject }}
          </div>
          <div class="todo__priority">
            {{ todo.priority }}
          </div>
          <div class="todo__tag">
            tagIcon
          </div>
          <div class="todo__">
            {{ todo.regDate }}
          </div>
          <div>
            <y-button
              width="50px"
              height="40px"
              backgroundColor="lightblue"
              text="수정" />
            <y-button
              width="50px"
              height="40px"
              backgroundColor="#EE5058"
              text="삭제" />
          </div>
        </li> -->
      </ul>
    </template>
    <template v-slot:tail>
      <div class="card__tail">
        각종 아이콘 메뉴
      </div>
    </template>
  </y-card>
</template>

<script>
import YInput from '@/components/YInput'
import YButton from '@/components/YButton'
import YCard from '@/components/YCard'
import TodoItem from './TodoItem'
export default {
  name: 'todo-list',
  components: {
    YInput,
    YButton,
    YCard,
    TodoItem,
  },
  // alternativeUrl: 'todo/todos',
  data() {
    return {
      name: 'TODO-LIST',
      inputValue: '',
      todoList: [],
    };
  },
  beforeMount() {
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
        id: String(-1),
        subject: title, 
        priority: 0,
        flag: 'N',
        regDate: new Date(),
      });
      this.inputValue = '';
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
    & > * {
      flex-grow: 1;
    }
  }
</style>