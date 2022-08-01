<template>
  <div class="yselect-div">
    <select 
      :value="modelValue"
      @change="onChange"
    >
      <option 
        v-for="(item, idx) in localData"
        :key="item.value + '__' + idx"
        :value="item.value"
      >{{ item.text }}</option>
    </select>
    {{ suffix }}
  </div>

</template>
<script>
import { ref, toRefs } from 'vue'
export default {
  name: 'y-select',
  emits: ['change', 'update:modelValue'],
  props: {
    data: {
      type: Array,
      default: () => [],
    },
    suffix: {
      type: String,
      default: '',
    },
    modelValue: {
      type: [String, Number],
      default: () =>  '',
    }
  },
  setup(props, { emit }) {
    
    const { data, modelValue } = toRefs(props)
    const localData = ref(data.value);

    // text, value가 없는 값이라면 text value로 만들어준다.
    localData.value = localData.value.map(value =>{
      let result = value;
      if (!(value && typeof (value) === 'object' && value.text && value.value)) {
        result = {
          text: value,
          value: value,
        }
      }
      return result;
    });

    // change
    const onChange = (e) => {
      emit('update:modelValue', e.target.value);
      emit('change', e.target.value, e);
    }


    return {
      localData,
      modelValue,
      onChange
    }
  },
  
}
</script>
