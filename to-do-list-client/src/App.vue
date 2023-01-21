<template>
  <div class="container">
    <router-view />
    <y-loading :loading="loading" />
    <template v-if="popupList.length">
      <y-popup :key="popup.id" v-for="popup in popupList" v-bind="popup" />
    </template>
  </div>
</template>
<script>
import YLoading from "@/components/common/YLoading";
import YPopup from "@/components/common/YPopup";
import { computed, onMounted } from "vue";
import { useStore } from "vuex";
export default {
  name: "App",
  components: {
    YLoading,
    YPopup,
  },
  setup() {
    const store = useStore();
    const loading = computed(() => store.getters.loading);
    const popupList = computed(() => store.getters.popupList);

    onMounted(() => {
      // setTimeout(() => {
      //   store.commit(
      //     "popup/MUT_POPUP_PUSH",
      //     {
      //       mode: "insert",
      //       id: 1,
      //       title: "테스트1",
      //       content: "테스트1입니다.",
      //     },
      //     1000
      //   );
      // });
    });
    return {
      loading,
      popupList,
    };
  },
};
</script>

<style lang="scss">
@import "@/sass/main.scss";

body {
  // overflow: hidden;
  overflow-y: auto;

}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  min-height: calc(100vh - 50px);
  width: 100%;
  position: relative;
}

.container {
  width: inherit;
  min-height: inherit;
  position: relative;
}
</style>
