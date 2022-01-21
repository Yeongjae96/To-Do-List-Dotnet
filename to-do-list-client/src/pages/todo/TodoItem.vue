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
  </li>
</template>

<script>
import YButton from '@/components/YButton';
export default {
  name: 'todo-item',
  components: {
    YButton,
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
  }
}
</script>

<style lang="scss" scoped>
  @import '@/sass/_mixin.scss';

  .todo__item {
    @include flexRow;
  
    &:not(:last-child) {
      margin-bottom: 20px;
    }

    & > * {
      @include flexRow;
      min-height: 30px;
      margin-right: 10px;
    }
    
    & .todo__subject {
      width: 50%;
    }
  }
</style>