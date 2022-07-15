<template>
  <div>
    <y-pagination :="pagination"/>
  </div>
</template>
<script>
import { ref } from 'vue' 
export default {
  props: {
    pagination: {
      type: Object,
      default: () => { return {}; },
    }
  },
  setup(props) {
    const pagination = ref(props.pagination);
    
    return {
      pagination
    }
  }
}
</script>
