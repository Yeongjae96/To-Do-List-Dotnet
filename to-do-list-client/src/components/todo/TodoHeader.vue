<template>
  <div>
    <div class="todo__alert">
      알림줄 &lt;구현예정 &gt;
      <y-select :data="pageSizeOptions" suffix="개" v-model="searchParam.pageSize" :type="Number" />
      <div class="right">
        <y-button width="10%" height="30px" borderColor="#EE5058" backgroundColor="white" text="Reload" :disableBorder="false"
          @click="reloadTodoList" />
      </div>
    </div>
    <div class="todo__insert">
      <y-input v-enter-debounce="100" type="text" width="90%" height="30px" borderColor="gray" v-model="inputValue" class="todo__insert__input"
        autoComplete="입력해주세요" @enter="insertTodo" />
      <y-button width="10%" height="30px" borderColor="black" backgroundColor="#EE5058" text="추가"
        @click="(e) => insertTodo(inputValue)" color="white" />
    </div>
  </div>
</template>

<script>
import { ref, computed } from 'vue'
import { useStore } from 'vuex'
import { simpleCreateTodo } from '@/composable/todo/todoEvent'
export default {
  name: 'todo-header',
  setup() {
    const store = useStore();

    const inputValue = ref('');

    const pageSizeOptions = [
      1, 5, 10, 15, 20
    ]

    const insertTodo = async (value) => {
    await simpleCreateTodo(value);
      store.dispatch('todoStore/ACT_GET_TODO_LIST');
      inputValue.value = '';
    }

    return {
      inputValue,
      insertTodo,
      pageSizeOptions,
      reloadTodoList: () => { store.commit('todoStore/MUT_CLEAR_SEARCH_PARAM'); store.dispatch('todoStore/ACT_GET_TODO_LIST') },
      searchParam: computed(() => store.state.todoStore.searchParam)
    }
  }
}
</script>

<style scoped lang="scss">
@import "@/sass/_mixin.scss";
.todo__alert {
  @include flexRow(stretch, center);
  position: relative;
  min-height: 30px;
}

.todo__insert {
  @include flexRow;

  &>*:not(:last-child) {
    margin-right: 10px;
  }

  & >:first {
    min-width: 80%;
    max-width: 80%;
  }
  & >:last-child {
    min-width: 20%;
    max-width: 20%;
  }
}
.right {
  position: absolute;
  right: 20px;
  top: 2px;
}
.todo__insert__input {
  border-bottom: 1px solid black;
}
</style>