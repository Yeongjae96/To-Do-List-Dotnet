<template>
  <transition name="slide-down">
    <div class="modal-mask" v-show="option.visible">
      <div class="modal-wrapper">
        <div class="modal-container" :style="computedStyle">
          <component :key="comp.name" :is="comp" />
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
import { mapGetters } from 'vuex'
import { POPUP } from '@/store/store-types'
export default {
  name: 'y-modal',
  props: {
    option: {
      type: Object,
      default: () => {
        return {
          visible: false,
          closeCallback: () => {},
          parameters: {},
          height: '100px',
          width: '80%',
        }
      },
    },
    comp: {
      type: [Function, Object],
      default: () => {
        return () => {};
      }
    },
    visible: {
      type: Boolean,
      default: () => false,
    },
    param: {
      type: Object,
      default: () => {
        return {};
      }
    },
    width: {
      type: String,
      default: () => '80%',
    },
    height: {
      type: String,
      default: () => '500px',
    }
  },
  computed: {
    ...mapGetters(POPUP),
    computedStyle() {
      return {
        width: this.width,
        height: this.height,
      }
    },
  },
  data() {
    return {
    };
  },
  watch: {
  },
  mounted() {
  },
  methods: {
    closeEvent() {
      if (this.option.closeCallback && typeof(this.option.closeCallback) === 'function') {
        this.option.closeCallback();
      }
      this.$emit('close');
    }
  },
}
</script>

<style lang="scss" scoped>
@import '@/sass/_mixin.scss';
  .modal-mask {
    position: fixed;
    z-index: 9000;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0,0,0, 0.5);
    transition: opacity ease 0.3;
    & .modal-wrapper {
      @include flexRow;
      position: relative;
      width: 100%;
      height: 100%;
      & .modal-container {
        width: 300px;
        margin: 0px auto;
        padding: 20px 30px;
        background-color: #fff;
        border-radius: 2px;
        box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
        transition: all 0.3s ease;
        font-family: Helvetica, Arial, sans-serif;
        & .modal-header h3 {
          margin-top: 0;
          color: #42b983;
        }

        & .modal-body {
          margin: 20px 0;
          }

        & .modal-default-button {
          float: right;
        }
      }
    }
  }
  .modal-enter {
    opacity: 0;
  }

  .modal-leave-active {
    opacity: 0;
  }

  .modal-enter .modal-container,
  .modal-leave-active .modal-container {
    -webkit-transform: scale(1.1);
    transform: scale(1.1);
  }
  .modal-body,
  .modal {
    color: #666 !important;
  }

</style>