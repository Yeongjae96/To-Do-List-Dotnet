<template>
  <div>
    <y-pagination @onClickPageNum="onChangePageSize" :="pagination" :pageSize="searchParam.pageSize"/>
  </div>
</template>
<script>
import { TODO } from '@/utils/Const'
import { computed } from 'vue'
import { useStore } from 'vuex' 
import { reloadTodoList } from '@/composable/todo/todoEvent'
export default {
  props: {},
  setup(props, { emit }) {

    const store = useStore();
    const searchParam = computed(() => store.state.todoStore.searchParam);

    const onChangePageSize = ({ pageNo }) => {
      store.commit('todoStore/MUT_SEARCH_PARAM_PAGE_NO', pageNo);
      store.dispatch('todoStore/ACT_GET_TODO_LIST');
    }

    return {
      onChangePageSize,
      searchParam,
      pagination: computed(() => store.state.todoStore.pagination),
    }
  }
}
</script>
