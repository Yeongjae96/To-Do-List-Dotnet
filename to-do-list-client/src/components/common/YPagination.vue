<template>
  <div class="flex row center pagination">
    <template v-if="isPrev">
      <div class="flex row center page-btn"
        @click="onClickPrev"
      >
        &lt;
      </div>
    </template>
    <template v-if="pageNo > 0">
      <div 
        v-for="(item) in currentRange"
        :key="'pagination__' + item"
        class="flex row center page-btn"
        :class="{ current: pageNo === item }"
        @click="onClickPage"
      >
        {{ item }}
      </div>
    </template>
    <template v-if="isNext">
      <div 
        class="flex row center page-btn"
        @click="onClickNext"
      >
        &gt;
      </div>
    </template>
  </div>  
</template>
<script>
import { computed, ref, toRefs, watch } from 'vue';

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
    pageSize: {
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
    },
  },
  setup(props, { emit }) { // toRefs -> 반응형을 잃어버리지 않으면서 값을 받아오는것
    const { isPrev, isNext, pageSize, currentMaxPageNum, currentMinPageNum, totalCnt } = toRefs(props);
    
    // localValue
    const localPageNo = ref(props.pageNo);

    // PageNum
    const initialPageNumbers = (item, idx) => currentMinPageNum.value + idx;
    const currentRange = computed(() => Array.from({ length: (currentMaxPageNum.value - currentMinPageNum.value + 1) }, initialPageNumbers));
    
    // watch
    watch(pageSize, () => {
      console.log('before', localPageNo.value);
      localPageNo.value = localPageNo.value * props.pageSize > props.totalCnt ? Math.ceil(totalCnt.value / props.pageSize) : localPageNo.value;
      console.log('after', localPageNo.value);
      emitClickPageNum('onClickPageNum', localPageNo.value);
    });

    // 이벤트
    const emitClickPageNum = () => {
      // emit하기전에 pageNo이 maxPageNum을 넘기면 보정해준다.
      
      emit('onClickPageNum', localPageNo.value)
    }; 

      // 이벤트
    const onClickPage = (e) => {
      if (/current/g.test(e.target.className)) return;
      localPageNo.value = Number(e.target.textContent);
      emitClickPageNum();
    }

    const onClickPrev = (e) => {
      localPageNo.value = currentMinPageNum.value - 1;
      emitClickPageNum();
    }

    const onClickNext = (e) => {
      localPageNo.value = currentMaxPageNum.value + 1;
      emitClickPageNum();
    }

    return {
      // state
      isPrev,
      isNext,
      totalCnt,
      currentRange,

      // event
      onClickPage,
      onClickPrev,
      onClickNext,
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