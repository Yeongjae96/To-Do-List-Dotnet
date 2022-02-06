<template>
  <input
    :type="type"
    :style="computedStyle"
    :autoComplete="autoComplete"
    :value="modelValue"
    :maxLength="maxLength"
    :readonly="readonly"
    @input="$emit('update:modelValue', $event.target.value)"
  />
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
  },
  mounted() {
    if (this.default) this.$emit("update:modelValue", this.default);
  },
  data() {
    return {};
  },

  computed: {},
  methods: {},
};
</script>
<style scoped>
input {
  outline: 0;
  border-top: 0;
  border-left: 0;
  border-right: 0;
  border-bottom: 1px solid;
  border-color: rgba(190, 190, 190, 0.8);
  padding-left: 5px;
}

input:focus {
  border: 1px solid;
  border-color: rgb(163, 147, 253);
}
</style>
