<template>
  <div>
    <div class="flex row">
      <div class="title w-20">
        할일제목
      </div>
      <div class="content w-80">내용</div>
    </div>
    <div class="flex row">
      <div class="title-data">
        {{ todo.title }}
      </div>
      <div class="content-data">
        {{ todo.content }}
      </div>
    </div>
  </div>
</template>

<script>
import { ref, toRefs, onMounted } from "vue";
import {
  getTodo
} from '@/api/TodoApi'
export default {
  name: "todo-update",
  props: {
    param: {
      type: Object,
      require: false,
    },
  },
  setup(props) {
    const { param } = toRefs(props);
    let todo = ref({
      title: '',
      content: '',
    });

    onMounted(async () => {
      todo.value = await getTodo(param.value.no);
      console.log(todo);
    });

    return {
      todo
    }
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin";
div.flex.row {
  @include flexRow;
}
</style>

