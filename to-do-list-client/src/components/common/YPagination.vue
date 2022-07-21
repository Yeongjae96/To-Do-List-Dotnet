<template>
  <div class="flex row center pagination">
    <template v-if="isPrev">
      &lt;
    </template>
    <template v-if="pageNo > 0">
      <div 
        v-for="(item) in currentRange"
        :key="'pagination__' + item"
        class="flex row center page-btn"
        :class="{ current: pageNo === item }"
        @click="onPageClick"
      >
        {{ item }}
      </div>
    </template>
    <template v-if="isNext">
      &gt;
    </template>
  </div>  
</template>
<script>
import { computed, toRefs } from 'vue';

export default {
  name: 'y-pagination',
  // emits: ['onClickPageNum'],
  props: {
    pageNumPerOnce: {
      type: Number,
      default: 10,
    },
    isPrev: {
      type: Boolean,
      default: false,
    },
    isNext: {
      type: Boolean,
      default: false,
    },
    pageNo: {
      type: Number,
      default: 0,
    },
    currentMinPageNum: {
      type: Number,
      default: 1,
    },
    currentMaxPageNum: {
      type: Number,
      default: 1,
    }, 
    totalCnt: {
      type: Number,
      default: 0,
    }
  },
  setup(props, { emit }) { // toRefs -> 반응형을 잃어버리지 않으면서 값을 받아오는것
    const { pageNo, isPrev, isNext, currentMaxPageNum, currentMinPageNum, totalCnt } = toRefs(props);
    
    // PageNum
    const initialPageNumbers = (item, idx) => currentMinPageNum.value + idx;
    const currentRange = computed(() => Array.from({ length: (currentMaxPageNum.value - currentMinPageNum.value + 1) }, initialPageNumbers));
    
      // 이벤트
    const onPageClick = (e) => {
      if (/current/g.test(e.target.className)) return;
      emit('onClickPageNum', e.target);
    }

    return {
      // state
      isPrev,
      isNext,
      pageNo,
      totalCnt,
      currentRange,

      // event
      onPageClick
    }
  }, 
}
</script>
<style scoped lang="scss">
  .page-btn {
    width: 30px;
    height: 30px;
    border: 1px solid #EE5058; 
    font-weight: bold;
    font-size: 1rem;
    cursor: pointer;

    &:not(:last-child) {
      margin-right: 10px;
    }
    &:hover {
      background-color: #E6E7EC;
      color: #333;
      border-color: #E6E7EC
    }
    &.current {
      background-color: #EE5058;
      color: white;

      &:hover {
        border-color: #EE5058;
      }
    }
  }

</style>