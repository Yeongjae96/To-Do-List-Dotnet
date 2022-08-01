<template>
  <div>
    <y-pagination @onClickPageNum="onChangePageSize" :="pagination"/>
  </div>
</template>
<script>
import { TODO } from '@/utils/Const'
import { inject, toRefs } from 'vue'
import { onChangePageSize } from '@/composable/todo/todoEvent'
export default {
  props: {},
  setup(props, { emit }) {

    const pagination = inject(TODO.provideKey.pagination);

    return {
      onChangePageSize,
      pagination
    }
  }
}
</script>
