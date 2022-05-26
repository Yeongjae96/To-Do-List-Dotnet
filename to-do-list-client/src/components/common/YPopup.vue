<template>
  <y-modal
    width="50%"
    height="80%"
    :title="title"
    :visible="true"
    @close="test"
  >
    <template #content>안녕하세요</template>
  </y-modal>
</template>

<script>
import { toRefs } from "vue";
import { useStore } from "vuex";
export default {
  name: "y-popup",
  props: {
    title: {
      type: String,
      default: "popup title!",
    },
    id: {
      type: [String, Number],
      required: true,
    },
  },
  setup(props) {
    const { title, id } = toRefs(props);
    const store = useStore();
    const test = () => {
      store.commit("popup/MUT_POPUP_REMOVE", { id: id.value });
    };
    return {
      title,
      test,
    };
  },
};
</script>

<style></style>