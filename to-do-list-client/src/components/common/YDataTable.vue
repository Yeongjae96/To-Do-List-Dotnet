<template>
  <div :id="id">
    <!-- <div data-role="colgroup">
      <col
        v-for="(h, hIdx) in header"
        :key="'__yDataTable__col__' + hIdx"
        :style="{ width: h.width }"
      />
    </div> -->
    <div data-role="thead">
      <div v-if="no"
        data-role="th"
        :style="{width: '60px'}"
      >
        No
      </div>
      <div data-role="th"
        v-for="(h, hIdx) in header"
        :key="'__yDataTable__th__' + hIdx"
        :style="calcThStyle(h)"
      >
        <div data-role="td">
          {{ h.text }}
        </div>
      </div>
    </div>
    <div data-role="tbody">
      <template v-if="!isLoading && (!data || data.length === 0)">
        <div data-role="tr-empty">
          <div data-role="td-empty">
            <y-icon size="2x" color="#666" :style="{marginRight:'10px'}"/>
            <p>
              데이터가 존재하지 않습니다.
            </p>
          </div>          
        </div>
      </template>
      <div data-role="tr" 
        v-for="(d, dIdx) in data"
        :key="'__yDataTable__tr__' + dIdx"
      >
        <!-- 특정 컴포넌트를 사용하는 경우 -->
        <div data-role="no" 
          v-if="no"
        >
          {{ paginationNo + dIdx + 1 }}
        </div>
        <template
          v-if="customComponent !== null"
          :style="{ flexGrow: 1, }"
        >
          <component 
            :is="customComponent" 
            :=d 
            :dtHeader="header"
            :isDataTable="true"
            @dtEvent="customComponentEventHandler"
          />
        </template>
        <!-- 헤더 옵션을 사용하는 경우 -->
        <template
          v-else
        >
          <div data-role="td"
            v-for="(hd, hdIdx) in header"
            :key="'__yDataTable__td__' + hd.text + '__' + dIdx + '__' + hdIdx"
            :style="calcTdStyle(hd)"
            @click="onClickTd(hd, d)"
          >
            <!-- -->
            <!-- icon -->
            <template
              v-if="hd.type === 'icon'"
            >
              <y-icon
                v-bind="{ ...hd.extensionProperties, ...convertComputedProperties(hd.compute, d) }"
              />
            </template>
            <template
              v-if="hd.type === 'custom'"
            >
              Custom Fields!!
            </template>
            {{ d[hd.key] }}
          </div>
        </template>
        
      </div>
    </div>
  </div>
</template>
<script>

import { computed, ref, shallowRef, toRefs, defineAsyncComponent } from 'vue'
import { useStore } from 'vuex'
import { calcTextAlign } from '@/composable/common/YDataTable'
export default {
  name: 'y-data-table',
  props: {
    id: {
      type: String,
      default: 'y-data-table',
    },
    header: {
      type: Array,
      default: () => []
    },
    data: {
      type: Array,
      default: () => []
    },
    template: {
      type: String,
      required: false,
    },
    no: {
      type: Boolean,
      default: false,
    },
    pageNo: {
      type: Number,
      default: 1,
    },
    pageSize: {
      type: Number,
      default: 0,
    }
  },
  setup(props, { emit }) {
    const { header, data, template, no, pageNo, pageSize } = toRefs(props);

    const customComponent = shallowRef(null);
    const localHeader = ref(null);

    // custom 컴포넌트가 있다면 로딩시켜놓고 async로 loading
    // 1. 동적 컴포넌트가 있다면, 동적 컴포넌트의 dtHeader 옵션이 있는지 체크 하고 있으면 이값을 최우선시로 가져온다.
    // 2. 동적 컴포넌트가 있지만, yDataTableHeader 옵션이 없으면 props를 바라본다.
    // 3. 동적 컴포넌트가 없으면 무조건 props만 바라본다.
    if (template.value) {
      const templatePromissedObject = import(`@/components/${template.value}.vue`);
      templatePromissedObject.then(comp => {
        customComponent.value = defineAsyncComponent(() => templatePromissedObject);
        localHeader.value = comp.default.dtHeader || header.value;
      });
    } else {
      localHeader.value = header.value;
    }
    // 동적 컴포넌트 불러오기

    const convertComputedProperties = (computedProperties, data) => {
      return Object.keys(computedProperties).reduce((prev, key) => prev[key] = computed(() => computedProperties[key](data)), {});
    } 
    
    // store
    const store = useStore();

    const calcThStyle = (hd) => {
      return {
        width: hd.width || false,
        flexGrow: !hd.width || hd.width === '*' ? 1 : 0,
        display: 'flex',
        justifyContent: 'center',
      }
    }

    const calcTdStyle = (hd) => {
      return {
        width: hd.width || false,
        flexGrow: !hd.width || hd.width === '*' ? 1 : 0,
        display: 'flex',
        justifyContent: calcTextAlign(hd.align),
      }
    }

    const onClickTd = (hd, d) => {
      console.log('emit, ', `tdClick:${hd.key}`);
      emit(`tdClick:${hd.key}`, d)
    }

    // customTemplate Event
    const customComponentEventHandler = ({ type, propertyName, value }) => {
      console.log('customComponentEventHandler', `${type}:${propertyName}`, value);
      emit(`${type}:${propertyName}`, value);
    }

    return {
      isLoading: computed(() => store.state.popup.loading),
      header: localHeader,
      data,
      calcThStyle,
      calcTdStyle,
      paginationNo: computed(() => (pageNo.value - 1) * pageSize.value),
      convertComputedProperties,
      customComponent,
      // localHeader: localHeader,
      onClickTd,
      customComponentEventHandler
    }
  }
}
</script>
<style scoped lang="scss">
@import "@/sass/_mixin.scss";
  div {
    &[data-role="thead"] {
      @include flexRow;
      border-bottom: 1px solid #333;
      padding: 5px 3px 5px 3px;
      // margin-bottom: 10px;
    }
    &[data-role="tbody"] {
      padding: 5px 3px 6px 3px;

    }
    &[data-role="th"] {
      @include flexRow(center, center);
      font-weight: bold;
      &:not(last-child) {
        border-right: 1px solid black;
      }
      // border-bottom: 1px solid #333;
      // border-top: 1px solid #333;
    }
    &[data-role="tr"] {
      @include flexRow;
      flex: 1 0 0%;
      min-height: 0;
      border-bottom: 0.5px solid #AAA;
      padding-bottom: 10px;
      padding-top: 10px;

      & div[data-role="no"] {
        width: 60px;
        @include flexRow(center, center);
      }

      &:hover {
        background-color: #EEE;
      }

      & > :not(div[data-role="no"]) {
        flex-grow: 1
      }
    }
    &[data-role="tr-empty"] {
      & div[data-role="td-empty"] {
        @include flexRow(center, center);
        min-height: 300px;

        & > * {
          @include flexRow(center, center);
          min-height: 30px;
        }

        & > p {
          font-weight: bold;
          font-size: 1.25rem;
        }
      }
    }
  }
  

</style>
