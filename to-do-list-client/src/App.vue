<template>
  <div class="container">
    <router-view />
    <y-loading :loading="loading" />
  </div>
</template>
<script>
import YLoading from "@/components/common/YLoading";
import { computed } from "vue";
import { useStore } from "vuex";
export default {
  name: "App",
  components: {
    YLoading,
  },
  setup() {
    const store = useStore();
    const loading = computed(() => store.getters.loading);
    return {
      loading,
    };
  },
};
</script>

<style lang="scss">
@import "@/sass/main.scss";

body {
  overflow: hidden;
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
