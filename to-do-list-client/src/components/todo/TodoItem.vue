<template>
  <li class="todo__item">
    <div class="todo__subject" :class="priority === 2 ? 'completed' : ''">
      {{ subject }}
    </div>
    <div class="todo__priority" @click="onClick('priority')">
      <y-icon 
        name="circle"
        :color="priorityColor"
      />
    </div>
    <div class="todo__tag" @click="onClick('tag')">
      <y-icon name="tags" fontSize="1.5rem" />
    </div>
    <div class="todo__reg_date">
      {{ regDate }}
    </div>
    <div class="todo__buttons">
      <y-button
        width="50px"
        height="40px"
        backgroundColor="lightblue"
        text="수정"
        color="white"
        @click="updateTodo" />
      <y-button
        width="50px"
        height="40px"
        backgroundColor="#EE5058"
        text="삭제"
        color="white"
        @click="deleteTodo(id)" />
    </div>
  </li>
</template>

<script>
export default {
  name: 'todo-item',
  inheritAttrs: false,
  components: {
  },
  props: {
    id: {
      type: String,
      default: () => '',
    },
    subject: {
      type: String,
      default: () => '',
    },
    priority: {
      type: Number,
      default: () => 0,
    },
    flag: {
      type: String,
      default: () => '',
    },
    regDate: {
      type: String,
      default: () => '',
    },
  },
  data() {
    return {
      updateMode: [],
    }
  },
  computed: {
    isSubjectUpdateMode() {
      return this.$_.includes(this.updateMode, 'subject');
    },
    priorityColor() {
      return this.$const.TODO.priorityColor[this.priority];
    },
    subjectStyle() {
      return this.priority === 1;
    },
  },
  created() {
  },
  methods: {
    deleteTodo() {
      this.$emit('delete', this.id);
    },
    updateTodo() {
      this.$emit('update', this.id);
    },
    onClick(tagName) {
      this.$emit('click', { tagName, id: this.id});
    }
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';

  .todo__item {
    @include flexRow;
    max-height: 30px;
  
    &:not(:last-child) {
      margin-bottom: 20px;
    }

    & > * {
      @include flexRow;
      margin-right: 10px;
    }
    
    & .todo__subject {
      width: 40%;
      padding-left: 20px;
      flex: 1;
    }

    & .todo__priority {
      width: 10%;
      cursor: pointer;
    }
    
    & .todo__tag {
      width: 10%;
    }
    & .todo__reg_date {
      width: 15%;
    }

    & .todo__buttons {
      width: 10%;

      @include notLastChild {
        margin-right: 5px;
      }
    }

    .completed {
      text-decoration: line-through;
    }

  }
</style>