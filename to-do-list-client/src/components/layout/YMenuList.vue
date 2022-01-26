<template>
  <ul class="menu">
    <y-menu-item v-for="menu in items" :key="menu.id" v-bind="menu" />
  </ul>  
</template>
<script>
import YMenuItem from './YMenuItem.vue'
export default {
  name: 'y-menu-list',
  components: {
    YMenuItem,
  },
  props: {
    items: {
      type: Array,
    }
  },
}
</script>
<style>
</style>