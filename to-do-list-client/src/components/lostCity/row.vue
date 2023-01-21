<template>
  <div class="lc-div" ref="lcRow">
    <div class="lc-icon">
      <y-image
        :src="imgName"
      />
    </div>
    <div class="lc-1p">
      <y-input v-model="localMy" :clear="false" type="number" className="lc-1p" :readonly="isSum" @change="(currValue) => updateValue('my', currValue)" />
    </div>
    <div class="lc-2p">
      <y-input v-model="localYour" :clear="false" type="number" className="lc-2p" :readonly="isSum" @change="(currValue) => updateValue('your', currValue)"/>
    </div>
  </div>
</template>
<script>
import { ref, toRefs, onMounted, computed, watch } from 'vue'
import th from '@/utils/typeHelper'
import { resizeItem, dtEmit } from '@/composable/common/YDataTable'
export default {
  dtHeader: [
    {
      text: '아이콘',
      key: 'imgName',
      width: '100px',
    },
    {
      text: '1P',
      key: 'my',
    },
    {
      text: '2P',
      key: 'your',
    }
  ],
  props: {
    imgName: {
      type: String,
      default: () => '',
    },
    my: {
      type: [Number, String],
      default: () => 0,
    },
    your: {
      type: [Number, String],
      default: () => 0,
    },
    dtHeader: {
      type: Array,
      default: () => [],
    },
    isSum: {
      type: Boolean,
      default: () => false,
    },
    totalList: {
      type: Array,
      default: () => [],
    },
    id: {
      type: [Number, String],
      default: () => 0,
    }
  },
  setup(props, context) {
    const { imgName, dtHeader, isSum, totalList, id } = toRefs(props);

    // 총 합산
    const getTotalValue = (target) => computed(() => totalList.value.filter(item => th.isNumber(item[target])).reduce((prev, curr) => prev + curr[target], 0));
    const getPropsValue = (target) => ref(props[target]);

    const localMy = isSum.value ? getTotalValue('my') : getPropsValue('my');
    const localYour = isSum.value ? getTotalValue('your') : getPropsValue('your');

    watch(() => props.my, (currValue) => { localMy.value = currValue})
    watch(() => props.your, (currValue) => { localYour.value = currValue})

    const lcRow = ref(null);

    // Width 보정
    onMounted(() => {
      resizeItem({ headerInfo: dtHeader.value, item: lcRow, });
    });

    const updateValue = (target, currValue) => {
      dtEmit({
        context,
        type: 'update',
        propertyName: 'value',
        value: {
          id: id.value,
          target,
          value: Number(currValue),
        }
      })
    }
    return {
      imgName,
      localMy,
      localYour,
      lcRow,
      updateValue
    }
  },
}
</script>
<style scoped lang="scss">
@import '@/sass/_mixin.scss';
  div {
    &.lc-div {
      @include flexRow(center, center);
    }

    &.lc-icon {
      @include flexRow(center, center);
    }
  }

  input {
    :deep(&.lc-1p), :deep(&.lc-2p) {
      // @include flexRow(center, center);
      text-align: center;
    }
  }
</style>