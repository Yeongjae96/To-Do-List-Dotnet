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
      default: '제목을 입력해주세요',
    },
    size: {
      type: String,
      default: 'sm',
    },
    fontSize: {
      type: String,
      default: '1rem'
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