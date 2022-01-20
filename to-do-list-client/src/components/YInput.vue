<template>
  <input :type="type" :value="value" :style="computedStyle"/>
</template>

<script>
export default {
  name: 'y-input',
  props: {
    type: {
      type: String,
      default: 'text',
    },
    value: {
      type: String,
      default: '',
    },
    width: {
      type: String,
      default: '100%',
    },
    height: {
      type: String,
      default: '50px',
    },
    borderColor: {
      type: String,
      default: 'black',
    }
  },
  computed: {
    computedStyle() {
      return {
        ...this.size,
        ...this.computedColor,
      }
    },
    size() {
      return {
        width: typeof(this.width) == 'number' ? `${this.width}px` : this.width,
        height: typeof(this.height) == 'number' ? `${this.height}px` : this.height
      }
    },
    computedColor() {
      return {
        borderBottomColor: this.borderColor,
      }
    }
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