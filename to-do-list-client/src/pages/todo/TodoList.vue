<template>
  <div class="todo__wrapper">
    <y-card>
      <template #title>
        {{ name }}
      </template>
      <template #content>
        <todo-header />
        <ul class="todo__list">
            <!-- :header="todoHeader"  -->
          <y-data-table 
            :data="todoList" 
            :template="templateUrl"
            :no="true"
            :pageSize="searchParam.pageSize"
            :pageNo="searchParam.pageNo"
            @click:completed="updateCompleted"
            @click:delete="onClickDelete"
            @click:header="onChangeSortOrder"
          />
        </ul>
      </template>
      <template #tail>
        <todo-footer />
      </template>
    </y-card>
    <y-modal :="modalOption" @close="() => (modalOption.visible = false)">
      <template #default>
        <component :key="currentCom.component" :is="currentCom.component" />
      </template>
    </y-modal>
  </div>
</template>
<script >
import _ from 'lodash';
import TodoItem from "@/components/todo/TodoItem";
import { ref, provide, watch, onMounted, computed  } from 'vue'
import { TODO } from '@/utils/Const'
import TodoHeader from '@/components/todo/TodoHeader';
import TodoFooter from "@/components/todo/TodoFooter";
import YDataTable from "@/components/common/YDataTable.vue";
import { useStore } from 'vuex'
import { useStore as us }from '@/store' 
// import { initTodoListPageData, initializeDataTable } from '@/composable/todo'
import { deleteTodo, updateTodoCompleted } from '@/composable/todo/todoEvent'
export default {
  name: "todo-list",
  components: {
    TodoItem,
    TodoHeader,
    TodoFooter,
    YDataTable
  },
  setup(props, context) {
    const name = '할 일 목록'

    // modalOption
    const modalOption = ref({
      visible: false,
      param: {},
      width: "90%",
      height: "90%",
      title: "",
      path: "",
    });
    const pageSizeOptions = ref([1, 5, 10, 15]);
    const inputValue = ref("");


    // store
    const todoStore = us('todoStore');
    const popupStore = us('popup');

    const templateUrl = 'todo/TodoItem';
    const searchParam = computed(() => todoStore.state.searchParam);


    const updateCompleted = async (value) => {
      await updateTodoCompleted(value);
      await todoStore.dispatch('ACT_GET_TODO_LIST');
    }

    onMounted(() => {
      todoStore.dispatch('ACT_GET_TODO_LIST');
    });

    const reloadTodoList = () => {
      todoStore.dispatch('ACT_GET_TODO_LIST');
    }

    const todoList = computed(() => todoStore.state.todoList);

    const onClickDelete = async (todo) => {
      // 공통 ALERT 
      // popupStore.commit('MUT_POPUP_PUSH', { type: TYPES.POPUP, id: todo.no })

      // onDelete
      // onDelete(todo);
    }
    const onDelete = async (todo) => { await deleteTodo(todo); todoStore.dispatch('ACT_GET_TODO_LIST') };
    const onChangeSortOrder = (key) => {
      let sort = _.find(todoStore.state.searchParam.sortCondition, { propertyName: key });
      if (!sort) sort = { propertyName: key, direction: null };
      sort.direction = sort.direction === 0 ? 1 : 0;

      todoStore.commit('MUT_CHANGE_SORT', sort);
      reloadTodoList()
    }
    return {
      // initializeParam
      name,
      searchParam,
      modalOption,
      pageSizeOptions,
      pagination: computed(() => todoStore.state.pagination),
      emptyMessage: '항목이 존재하지 않습니다.',
      inputValue,
      todoList,

      templateUrl,

      // event
      updateCompleted,
      onClickDelete,
      onChangeSortOrder
    };
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

.todo__wrapper {
  width: 100%;
  height: 100%;
}

.todo__list {
  flex: 1;
}
.todo__insert div {
  outline: 0;
  border-top: 0;
  border-left: 0;
  border-right: 0;
  border-bottom: 1px solid;
  border-color: rgba(190, 190, 190, 0.8);
  padding: 5px 5px 5px 10px;
  margin-left: 2px;
  margin-top: 1px;

  &:focus {
    border: 1px solid;
    border-color: rgb(163, 147, 253);
    margin-left: 0px;
    margin-top: 0px;
  }
}

li[role="dataHeader"] {
  @include flexRow;
}
</style>
