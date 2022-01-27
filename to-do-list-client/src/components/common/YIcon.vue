<template>
  <font-awesome-icon :class="className" :icon="['fas', name]" :size="size" :style="computedStyle"/>
</template>

<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
export default {
  name: 'y-icon',
  components: {
    FontAwesomeIcon,
  },
  props: {
    className: {
      type: [String, Array],
      default: () => '',
    },
    name: {
      type: String,
      default: 'times',
    },
    size: {
      type: String,
      default: 'sm',
    },
    fontSize: {
      type: String,
      default: '1rem'
    },
    color: {
      type: String,
      default: 'black',
    },
    pointer: {
      type: Boolean,
      default: false,
    }
  },
  data() {
    return {
      style: {},  
    };
  },
  computed: {
    computedStyle() {
      return {
        color: this.color,
        fontSize: this.fontSize,
        cursor: this.pointer ? 'pointer' : '',
      }
    }
  },
  mounted() {
  },
  methods: {
  }
}
</script>
<style scoped>
  
</style>