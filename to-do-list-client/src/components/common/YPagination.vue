<template>
  <div class="pagination">
    <template v-if="totalCnt != null">
      <template 
        v-for="(item, idx) in pagination"
        :key="'pagintaion__' + idx"
      >
        {{ idx }}
      </template>
    </template>
  </div>  
</template>
<script>
import { ref } from 'vue';

export default {
  props: {
    pageNo: {
      type: Number,
      default: 1,
    },
    totalCnt: {
      type: Number,
      default: 0,
    }
  },
  setup(props) {
    const { pageNo, totalCnt } = props;
    return {
      pageNo,
      totalCnt,
    }
  },  
}
</script>
