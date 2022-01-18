<template>
  <li class="menu_item__li">
    <y-icon :name="icon" :size="imageSize"/>
    <router-link :to="url">
      {{title}}
    </router-link>
  </li>
</template>

<script>
export default {
  name: 'y-menu-item',
  props: {
    title: {
      type: String,
    },
    url: {
      type: String,
      default: '',
    },
    icon: {
      type: String,
      default: '',
    },
    imageSize: {
      type: String,
      default: 'sm',
    }
  },
  data() {
    return {
    }
  }
}
</script>

<style>

</style>