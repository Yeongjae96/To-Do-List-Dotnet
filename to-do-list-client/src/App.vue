<template>
  <router-view></router-view>
  <y-loading :loading="loading" />
</template>
<script>
import YLoading from "@/components/common/YLoading";
export default {
  name: "App",
  components: {
    YLoading,
  },
  data() {
    return {
      loading: false,
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
</style>
