<template>
  <li class="todo__item">
    <div class="todo__no">
      {{ id + 1 }}
    </div>
    <div class="todo__subject" :class="{ completed }">
      {{ title }}
    </div>
    <div class="todo__completed" @click="onClick('completed')">
      <y-icon name="circle" :color="completedColor" />
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
        @click="updateTodo"
      />
      <y-button
        width="50px"
        height="40px"
        backgroundColor="#EE5058"
        text="삭제"
        color="white"
        @click="deleteTodo(no)"
      />
    </div>
  </li>
</template>

<script>
export default {
  name: "todo-item",
  inheritAttrs: false,
  components: {},
  props: {
    no: {
      type: Number,
      default: 1,
    },
    id: {
      type: [String, Number],
      default: () => "",
    },
    title: {
      type: String,
      default: () => "",
    },
    flag: {
      type: String,
      default: () => "",
    },
    regDate: {
      type: String,
      default: () => "",
    },
    completed: {
      type: Boolean,
      default: () => false,
    },
  },
  data() {
    return {
      updateMode: [],
    };
  },
  computed: {
    isSubjectUpdateMode() {
      return this.$_.includes(this.updateMode, "subject");
    },
    completedColor() {
      return this.$const.TODO.completedColor[this.completed];
    },
    subjectStyle() {
      return this.completed;
    },
  },
  created() {},
  methods: {
    deleteTodo() {
      this.$emit("delete", this.no);
    },
    updateTodo() {
      this.$emit("update", this.no);
    },
    onClick(tagName) {
      this.$emit("click", { tagName, no: this.no });
    },
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

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

  & .todo__completed {
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
