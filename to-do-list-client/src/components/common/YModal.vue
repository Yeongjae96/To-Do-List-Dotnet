<template>
  <transition name="slide-fade" mode="out-in">
    <div class="modal-mask" v-show="visible">
      <div class="modal-wrapper">
        <div class="modal-container" :style="computedStyle">
          <div class="modal-header">
            <h3>
              {{ title }}
            </h3>
            <y-icon
              name="times"
              fontSize="2rem"
              color="lightgrey"
              hover="#EE5058"
              pointer
              @click="closePopup"
            />
          </div>
          <div class="modal-body">
            <component
              v-if="visible"
              :key="title"
              :is="componentFile"
              :param="param"
            />
            <!-- <slot name="default">기본값</slot> -->
          </div>
          <div class="modal-footer">
            <slot name="footerButtonList"></slot>
            <y-button
              @click="closePopup"
              :text="'닫기'"
              width="80px"
              height="40px"
            />
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
import { mapGetters } from "vuex";
import { POPUP } from "@/store/store-types";
import { defineAsyncComponent } from "vue";
export default {
  name: "y-modal",
  props: {
    title: {
      type: String,
      default: "Title",
    },
    visible: {
      type: Boolean,
      default: () => false,
    },
    param: {
      type: Object,
      default: () => {
        return {};
      },
    },
    width: {
      type: String,
      default: () => "90%",
    },
    height: {
      type: String,
      default: () => "600px",
    },
    closeCallback: {
      type: Function,
    },
    path: {
      type: String,
      default: () => "",
    },
  },
  computed: {
    ...mapGetters(POPUP),
    computedStyle() {
      return {
        width: this.width,
        height: this.height,
      };
    },
    componentFile() {
      return defineAsyncComponent(() => import(`@/pages${this.path}.vue`));
    },
  },
  data() {
    return {};
  },
  watch: {},
  created() {},
  mounted() {},
  methods: {
    closePopup() {
      if (this.closeCallback && typeof this.closeCallback === "function") {
        this.closeCallback();
      }
      this.$emit("close");
    },
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";
.modal-mask {
  position: fixed;
  z-index: 9000;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  transition: all ease 0.3;
  & .modal-wrapper {
    @include flexRow;
    position: relative;
    width: 100%;
    height: 100%;
    & .modal-container {
      @include flexColumn;
      width: 300px;
      margin: 0px auto;
      background-color: #fff;
      border-radius: 2px;
      position: relative;
      box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
      transition: all 0.3s ease-in-out;
      font-family: Helvetica, Arial, sans-serif;
      & .modal-header {
        @include flexRow;
        padding: 0 20px 0 20px;
        justify-content: space-between;
        background-color: #272727;
        & h3 {
          @include flexRow;
          width: 50%;
          min-height: 30px;
          padding: 10px 0 10px 0;
          margin-top: 0;
          font-size: 1.5rem;
          font-weight: bold;
          border-bottom: 1px solid lightgray;
          color: lightgrey;
        }
      }

      & .modal-body {
        margin: 20px 0;
        padding: 20px 30px;
        flex-grow: 1;
        overflow: auto;
        height: 0px;
      }

      & .modal-footer {
        display: flex;
        justify-content: flex-end;
        position: relative;
        padding: 0 10px 5px 0;
        transform: translateY(-100%);
        margin-top: 20px;
        height: 20px;
      }
    }
  }
}

.modal-body,
.modal {
  color: #666 !important;
}
</style>
