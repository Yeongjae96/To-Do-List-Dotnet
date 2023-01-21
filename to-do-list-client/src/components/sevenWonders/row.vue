<template>
  <div class="s-div" ref="sevenWondersRow" @click="rowClick">
    <div class="s-icon">
      <y-image :src="imgName" />
    </div>
    <div class="s-number">
      <template v-if="isSum">
        <y-input className="s-my" v-model="total1P" type="number" :clear="false" :readonly="true"/>
      </template>
      <template v-else-if="isCheck">
        <y-input className="s-my" v-model="localMy" type="checkbox" :clear="false" @change="updateValue"/>
      </template>
      <template v-else>
        <y-input className="s-my" v-model="localMy" :clear="false" type="number" @change="(value) => updateValue('my', value)"/>
      </template>
    </div>
    <div class="s-number2">
      <template v-if="isSum">
        <y-input className="s-your" v-model="total2P" type="number" :clear="false" :readonly="true"/>
      </template>
      <template v-else-if="isCheck">
        <y-input className="s-your" v-model="localYour" type="checkbox" :clear="false"/>
      </template>
      <template v-else>
        <y-input className="s-your" v-model="localYour" :clear="false" type="number" @change="(value) => updateValue('your', value)"/>
      </template>
    </div>
  </div>
</template>

<script>
import { ref, toRefs, onMounted, computed, watch } from 'vue'
import { resizeItem, dtEmit } from '@/composable/common/YDataTable'
import th from '@/utils/typeHelper'

export default {
  dtHeader: [
    { text: '아이콘', width: '100px', key: 'imgName', align: 'center' },
    { text: '1P', key: 'my', align: 'right' },
    { text: '2P', key: 'your', align: 'right' },
  ],
  emits: ['dtEvent'],
  props: {
    imgName: {
      type: String, 
      default: () => '',
    },
    isCheck: {
      type: Boolean,
      default: false,
    },
    bColor: {
      type: String,
      default: () => '',
    },
    bhColor: {
      type: String,
      default: () => '',
    },
    my: {
      type: [Number, Boolean],
      default: 0,
    },
    your: {
      type: [Number, Boolean],
      default: 0,
    },
    isSum: {
      type: Boolean,
      default: () => false,
    },
    dtHeader: {
      type: Array,
      default: () => [],
    },
    totalList: {
      type: Array,
      default: () => [],
    },
    id: {
      type: [String, Number],
      required: true,
    }
  },
  setup(props, context) {
    const { dtHeader, bColor, bhColor, imgName, isCheck, totalList, id } = toRefs(props);

    const localMy = ref(props.my);
    const localYour = ref(props.your);

    const total1P = computed(() => totalList.value.filter(item => th.isNumber(item.my)).reduce((prev, curr) => prev + curr.my, 0))
    const total2P = computed(() => totalList.value.filter(item => th.isNumber(item.your)).reduce((prev, curr) => prev + curr.your, 0))

    const sevenWondersRow = ref(null);
    
    const updateValue = (target, currValue) => {
      dtEmit({
        type: 'update',
        propertyName: 'value',
        value: {
          id: id.value,
          target,
          value: currValue,
        },
        context,
      })
    }

    const rowClick = (target, currValue) => {
      dtEmit({
        type: 'click',
        propertyName: 'row',
        value: {
          target
        },
        context,
      })
    }

    watch(() => props.my, (changedValue) => {
      localMy.value = changedValue;
    })

    watch(() => props.your, (changedValue) => {
      localYour.value = changedValue;
    })

    // Width 보정
    onMounted(() => {
      resizeItem({ headerInfo: dtHeader.value, item: sevenWondersRow, });
    });

    return {
      sevenWondersRow,
      isCheck,
      localMy,
      localYour,
      total1P,
      total2P,
      bColor,
      bhColor,
      imgName,
      updateValue,
      rowClick
    }
  } 
}
</script>

<style scoped lang="scss">
@import "@/sass/_mixin.scss";
  div {
    &.s-div {
      @include flexRow;
      background-color: v-bind(bColor);
      opacity: 0.7;
       
      &:hover {
        background-color: v-bind(bhColor);
      }
    }
  }

  input {
    :deep(&.s-my), :deep(&.s-your)  {
      // @include flexRow(center, center);
      text-align: center;
      font-size: 24px;
      font-weight: bold;
    }
  }
</style>