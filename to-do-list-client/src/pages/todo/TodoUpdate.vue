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
  props: {
    param: {
      type: Object,
      require: false,
    },
  },
  setup(props) {
    onMounted(() => {
      console.log("is Mounted!!");
    });
    console.log(props.param);
  },
  name: "todo-update",
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin";
div.flex.row {
  @include flexRow;
}
div.w-20 {
  width: 20%;
}
div.w-40 {
  width: 40%;
}
div.w-60 {
  width: 60%;
}
div.w-80 {
  width: 80%;
}
</style>
