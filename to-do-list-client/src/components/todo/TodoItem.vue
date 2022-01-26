<template>
  <li class="todo__item">
    <div class="todo__subject">
      {{ subject }}
    </div>
    <div class="todo__priority">
      {{ priority }}
    </div>
    <div class="todo__tag">
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
        @click="updateTodo" />
      <y-button
        width="50px"
        height="40px"
        backgroundColor="#EE5058"
        text="삭제"
        :effect="true"
        @click="deleteTodo(id)" />
    </div>
  </li>
</template>

<script>
export default {
  name: 'todo-item',
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
    }
  },
  methods: {
    deleteTodo(id) {
      this.$emit('delete', id);
    },
    updateTodo() {
      this.$emit('update', this.id);
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
      width: 50%;
    }

    & .todo__priority {
      width: 10%;
    }

    
    & .todo__tag {
      width: 10%;
    }
    & .todo__reg_date {
      width: 20%;
    }

    & .todo__buttons {
      width: 10%;

      @include notLastChild {
        margin-right: 5px;
      }
    }

  }
</style>