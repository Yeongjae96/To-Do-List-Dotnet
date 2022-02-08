<template>
  <div class="loading-background" v-show="loading">
    <div class="v-spinner">
      <div class="v-clip" :style="computedStyle"></div>
      <p class="loading-text">{{ loadingText }}</p>
    </div>
    <!--v-component-->
  </div>
</template>

<script>
import { ref, computed, watch, toRef } from "vue";
import _ from "lodash";

export default {
  name: "y-loading",
  props: {
    loading: {
      type: Boolean,
      default: false,
    },
  },
  setup(props) {
    const computedStyle = computed(() => {
      return {
        position: "absolute",
        height: "120px",
        width: "120px",
        borderWidth: "10px",
        borderStyle: "solid",
        borderColor: "rgb(93, 197, 150) rgb(93, 197, 150) transparent",
        borderRadius: "100%",
        background: "transparent",
      };
    });

    const loading = toRef(props, "loading");
    const dotCount = ref(0);
    const loadingText = computed(() => {
      return `Loading${_.repeat(".", dotCount.value)}`;
    });

    let repeatFunction = null;
    watch(loading, (newValue) => {
      if (newValue) {
        repeatFunction = setInterval(() => {
          dotCount.value = (dotCount.value + 1) % 6;
        }, 500);
      } else {
        clearTimeout(repeatFunction);
      }
    });
    return {
      computedStyle,
      loadingText,
    };
  },
};
</script>

<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

.loading-background {
  width: 100%;
  height: 100vh;
  position: absolute;
  top: 0;
  left: 0;
  background-color: rgba(0, 0, 0, 0.3);
}

.loading-text {
  size: 1.5rem;
  font-weight: bold;
  color: #eee;
  z-index: 10;
  position: relative;
  animation: v-scale 0.75s 0s infinite linear;
}
.v-spinner {
  @include flexRow(center, center);
  width: 100%;
  height: 100%;
}

.v-spinner .v-clip {
  -webkit-animation: v-clipDelay 0.75s 0s infinite linear;
  animation: v-clipDelay 0.75s 0s infinite linear;
  -webkit-animation-fill-mode: both;
  animation-fill-mode: both;
  transform: translate(-50%, -50%);
  display: inline-block;
}

@keyframes v-clipDelay {
  0% {
    -webkit-transform: rotate(0deg) scale(1);
    transform: rotate(0deg) scale(1);
  }
  50% {
    -webkit-transform: rotate(180deg) scale(0.8);
    transform: rotate(180deg) scale(0.8);
  }
  100% {
    -webkit-transform: rotate(360deg) scale(1);
    transform: rotate(360deg) scale(1);
  }
}

@keyframes v-scale {
  0% {
    -webkit-transform: scale(1);
    transform: scale(1);
  }

  50% {
    -webkit-transform: scale(0.8);
    transform: scale(1.1);
  }

  100% {
    -webkit-transform: scale(1);
    transform: scale(1);
  }
}
</style>
