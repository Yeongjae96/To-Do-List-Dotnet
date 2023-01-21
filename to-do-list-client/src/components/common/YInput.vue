<template>
  <div
    v-if="isEdit"
    class="yinput-wrapping-div"
    :style="wrappingDivStyle"
  >
    <input
      ref="internalInput"
      :class="className"
      :type="type"
      :style="inputStyle"
      :autoComplete="autoComplete"
      :value="modelValue"
      :maxLength="maxLength"
      :readonly="readonly"
      @change.stop="onChange"
      @input="$emit('update:modelValue', $event.target.value)"
      @focusout.stop="onFocusout"
      @keyup.enter.stop="onEnter"
    />

    <y-icon 
      v-if="clear"
      class="ic-times"
      color="gray"
      hover="#EE5058"
      size="sm"
      :style="{ cursor: 'pointer' }"
      @click="onClickClear"
    /> 
  </div>
    <!-- @keyup.enter.stop="onEnter"
    @focusout="onFocusout" -->
  <p  
    v-else
  >
    {{ modelValue }}
  </p>
  <!-- @keypress.enter="$emit('enter', $event.target.value)" -->
</template>

<script>
import ComponentPropertyMixin from "@/mixin/ComponentPropertyMixin";
export default {
  name: "y-input",
  mixins: [ComponentPropertyMixin],
  emits: ['focusout', 'enter', 'update:modelValue', 'change'],
  props: {
    type: {
      type: String,
      default: "text",
    },
    className: {
      type: String,
      default: () => '',
    },
    autoComplete: {
      type: String,
      default: "입력해주세요",
    },
    modelValue: {
      type: [String, Number, Boolean],
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
    },
    clear: {
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

  computed: {
    wrappingDivStyle() {
      return this.getComputedStyle(['size', 'computedBorder']);
    },
    inputStyle() {
      return {
        ...this.getComputedStyle(['computedBackgroundColor']),
        border: 0,
      };
    }
  },
  methods: {
    onChange(e) {
      this.$emit('change', this.modelValue, e);
    },
    onEnter(e) {
      // e.stopPropagation();
      this.isEnterPress = true;
      this.$emit('enter', this.modelValue, e);
      
    },
    onFocusout(e) {
      // e.stopPropagation();
      if (this.isEnterPress) {
        this.isEnterPress = false;
        return;
      }
      this.$emit('focusout', this.modelValue, e);
    },
    onClickClear(e) {
      this.$emit('update:modelValue', '');
      this.$refs.internalInput.focus();
    }
  },
};
</script>
<style lang="scss" scoped>
@import "@/sass/_mixin.scss";

input {
  width: 100%;
  &[type="text"] {
    font-size: 1rem;
  }
  &:focus {
    outline: 0;
  }
}

p {
  @include flexRow(center, center);
  padding: 1px 2px;
}

.yinput-wrapping-div {
  @include flexRow(stretch, center);
  position: relative;
}


div.ic-times {
  margin-left: 10px;
  position: relative;
  right: 5px;
  // top: 3px;
  height: 25px;
  font-size: 1.5rem !important;
}
</style>
