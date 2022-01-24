<template>
  <button :type="type" :style="computedStyle" @click.stop="clickEvent">
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
  },
  methods: {
    clickEvent(e) {
        this.$emit('click', e)
    },
  },
}
</script>
<style lang="scss" scoped>
  button {
    background-color: inherit;
    font-weight: bold;
    border-width: 1px;
    position: relative;
    overflow: hidden;
    transition: all 0.8s;
    color: #fff;
    outline: 0;
    border: 0;
    border-radius: 0.25rem;
    box-shadow: 0 0 0.5rem rgba(0, 0, 0, 0.3);
    cursor: pointer;

    &:after {
      content: '';
      position: absolute; /* The absolute position we mentioned earlier */
      border-radius: 40%;
      width: 100%;
      height: 100%;
      top: 0;
      left: 0;
      background-color: #EEEEEE;
      transform: scale(2);
      opacity: 0;
      transition: all 0.8s
    }
    &:active:after {
      content: '';
      opacity: 1;
      background-color: inherit;
      transform: scale(0);
      transition: 0s
    }
  }


</style>
