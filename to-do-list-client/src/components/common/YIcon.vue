<template>
  <div :style="computedStyle">
    <font-awesome-icon :class="className" :icon="['fas', name]" :size="size" />
    <!-- :style="computedStyle" -->
  </div>
</template>

<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
export default {
  name: "y-icon",
  components: {
    FontAwesomeIcon,
  },
  props: {
    className: {
      type: [String, Array],
      default: () => "",
    },
    name: {
      type: String,
      default: "times",
    },
    size: {
      type: String,
      default: "sm",
    },
    fontSize: {
      type: String,
      default: "1rem",
    },
    color: {
      type: String,
      default: "black",
    },
    pointer: {
      type: Boolean,
      default: false,
    },
    hover: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      style: {},
    };
  },
  computed: {
    computedStyle() {
      return {
        fontSize: this.fontSize,
        cursor: this.pointer ? "pointer" : "",
        "--color": this.color,
        "--color-hover": this.hover || this.color,
      };
    },
  },
  mounted() {},
  methods: {},
};
</script>
<style lang="scss" scoped>
div {
  color: var(--color);
  &:hover {
    color: var(--color-hover);
  }
}
</style>
