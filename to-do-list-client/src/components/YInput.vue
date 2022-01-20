<template>
  <input :type="type" :value="value" :style="computedStyle"/>
</template>

<script>
import ComponentPropertyMixin from '@/mixin/ComponentPropertyMixin'
export default {
  name: 'y-input',
  mixins: [ComponentPropertyMixin],
  props: {
    type: {
      type: String,
      default: 'text',
    },
    value: {
      type: String,
      default: '',
    },
  },
  computed: {
  },
  methods: {
  },
}
</script>
<style scoped>
  input {
    outline: 0;
    border-top: 0 ;
    border-left: 0; 
    border-right: 0; 
    border-bottom: 2px solid;
  } 
</style>