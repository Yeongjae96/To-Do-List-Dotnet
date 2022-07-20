<template>
  <input
    v-if="isEdit"
    :type="type"
    :style="computedStyle"
    :autoComplete="autoComplete"
    :value="modelValue"
    :maxLength="maxLength"
    :readonly="readonly"
    @input="$emit('update:modelValue', $event.target.value)"
  />
  
    <!-- @keyup.enter.stop="onEnter"
    @focusout="onFocusout" -->
  <span 
    v-else
  >
    {{ modelValue }}
  </span>
  <!-- @keypress.enter="$emit('enter', $event.target.value)" -->
</template>

<script>
import ComponentPropertyMixin from "@/mixin/ComponentPropertyMixin";
export default {
  name: "y-input",
  mixins: [ComponentPropertyMixin],
  props: {
    type: {
      type: String,
      default: "text",
    },
    autoComplete: {
      type: String,
      default: "입력해주세요",
    },
    modelValue: {
      type: String,
      default: "",
    },
    default: {
      type: String,
      default: "",
    },
    maxLength: {
      type: Number,
      default: () => 30,
    },
    readonly: {
      type: Boolean,
      default: false,
    },
    isEdit: {
      type: Boolean,
      default: true,
    }
  },
  mounted() {
    if (this.default) this.$emit("update:modelValue", this.default);
  },
  data() {
    return {
      isEnterPress: false,
    };
  },

  computed: {},
  methods: {
    onEnter(e) {
      e.stopPropagation();
      this.isEnterPress = true;
      this.$emit('enter', this.modelValue, e);
    },
    onFocusout(e) {
      e.stopPropagation();
      if (this.isEnterPress) {
        this.isEnterPress = false;
        return;
      }
      this.$emit('focusout', this.modelValue, e);
    }
  },
};
</script>
<style lang="scss" scoped>
input {
  &:focus {
    outline: 0;
  }
}
</style>
