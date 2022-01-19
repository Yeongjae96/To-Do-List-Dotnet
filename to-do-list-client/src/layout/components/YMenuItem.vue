<template>
  <li class="menu_item__li" @click="routeLink">
    <y-icon :name="icon" :size="imageSize"/>
    <p>
      {{title}}
    </p>
    <!-- <router-link :to="url">
      {{title}}
    </router-link> -->
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
  },
  methods: {
    routeLink() {
      this.$router.push(this.url);
    }
  }
}
</script>

<style>

</style>