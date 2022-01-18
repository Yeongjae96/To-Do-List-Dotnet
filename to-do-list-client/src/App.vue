<template>
  <y-layout>
    <router-view></router-view>
  </y-layout>
</template>

<script>

import YLayout from '@/layout'

export default {
  components: {
    YLayout
  },
  name: 'App',
  data() { return {}}
}
</script>

<style lang="scss">
@import '@/sass/main.scss';
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;
}
</style>
