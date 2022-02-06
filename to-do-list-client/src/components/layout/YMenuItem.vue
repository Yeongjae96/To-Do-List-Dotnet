<template>
  <router-link :to="url" v-slot="{ navigate, isActive, isExactActive }">
    <li
      class="menu_item__li"
      @click="navigate"
      :class="[
        isActive && 'active',
        isExactActive && 'router-link-exact-active',
      ]"
    >
      <y-icon :name="icon" :size="imageSize" />
      <p>
        {{ title }}
      </p>
    </li>
  </router-link>
</template>

<script>
export default {
  name: "y-menu-item",
  props: {
    title: {
      type: String,
    },
    url: {
      type: String,
      default: "",
    },
    icon: {
      type: String,
      default: "",
    },
    imageSize: {
      type: String,
      default: "sm",
    },
    isActive: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    routeLink() {
      this.$router.push(this.url);
    },
  },
};
</script>

<style></style>
