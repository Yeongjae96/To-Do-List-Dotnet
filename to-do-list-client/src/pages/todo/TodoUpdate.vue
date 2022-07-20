<template>
  <div>
    <div class="flex row">
      <div class="title w-20">할일제목</div>
      <div class="content w-80">내용</div>
    </div>
  </div>
</template>

<script>
import { onMounted } from "vue";
export default {
  name: "todo-update",
  props: {
    param: {
      type: Object,
      require: false,
    },
  },
  setup(props) {
    onMounted(() => {
    });
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin";
div.flex.row {
  @include flexRow;
}
</style>

