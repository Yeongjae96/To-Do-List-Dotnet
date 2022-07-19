<template>
  <div>
    <y-pagination @onClickPageNum="onClickPageNum" :="pagination"/>
  </div>
</template>
<script>
import { toRefs } from 'vue' 
export default {
  props: {
    pagination: {
      type: Object,
      default: () => { return {}; },
    }
  },
  setup(props, { emit }) {
    const { pagination } = toRefs(props);

    const onClickPageNum = (e) => emit('onClickPageNum', e);

    return {
      onClickPageNum,
      pagination
    }
  }
}
</script>
