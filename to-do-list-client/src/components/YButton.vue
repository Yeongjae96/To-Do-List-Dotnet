<template>
  <button :type="type" :style="computedStyle">
    {{ text }}
  </button>
</template>

<script>
import ComponentPropertyMixin from '@/mixin/ComponentPropertyMixin'
export default {
  name: 'y-button',
  mixins: [ComponentPropertyMixin],
  props: {
    type: {
      type: String,
      default: 'button',
    },
  },
  computed: {
  }
}
</script>
<style scoped>
  button {
    background-color: inherit;
    font-weight: bold;
    border-width: 1px;
  }
</style>
