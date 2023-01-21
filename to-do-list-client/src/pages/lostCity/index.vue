<template>
  <div>
    <y-data-table
      template="lostCity/row"
      :data="data"
      @update:value="onUpdateRow"
    />
  </div>
</template>
<script>
import { ref } from 'vue'
import _ from 'lodash'
export default {
  setup() {
    const data = ref([
      { id: 1, imgName: 'lostCity/1.png', my: 0, your: 0 },
      { id: 2, imgName: 'lostCity/2.png', my: 0, your: 0 },
      { id: 3, imgName: 'lostCity/3.png', my: 0, your: 0 },
      { id: 4, imgName: 'lostCity/4.png', my: 0, your: 0 },
      { id: 5, imgName: 'lostCity/5.png', my: 0, your: 0 },
      { id: 6, imgName: 'lostCity/6.png', my: 0, your: 0 },
      { id: 7, imgName: 'sevenWonders/10.png', isSum: true, },
    ]);

    const onUpdateRow = (value) => {
      console.log(value);
      const target = _.find(data.value, item => item.id === value.id);
      if (!target) throw new Error('Not Found LostCity ID');
      target[value.target] = value.value;
    }

    return {
      data,
      onUpdateRow,
    }
  },
}
</script>
