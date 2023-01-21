<template>
  <div class="sw-div">
    <y-data-table
      :template="templateUrl"
      :data="data"
      @update:value="updateValue"
      @click:row="onClickRow"
    />
  </div>
</template>
<script>
import _ from 'lodash'
import { ref, onBeforeUnmount } from 'vue'
export default {
  name: 'seven-wonders-list',
  setup() {
    // 1. connect websocket 
    const connection = new WebSocket("ws://localhost:8001/ws")
    connection.onmessage = (event) => {
      console.log(event);
    }

    connection.onopen = (event) => {
      console.log(event);
      console.log('Successfully connected to the echo websocket server...');
    }

    connection.onclose = (event) => {
      console.log(event);
      console.log('Close Connection to the echo websocket server...')
    }

    onBeforeUnmount(() => {
      connection.close();
    });

    const data = ref([
      { id: 1, imgName: 'sevenWonders/1.png', my: 0, your: 0, bColor: 'white' },
      { id: 2, imgName: 'sevenWonders/2.png', my: 0, your: 0, bColor: 'lightblue' },
      { id: 3, imgName: 'sevenWonders/3.png', my: 0, your: 0, bColor: 'lightgreen', bhColor: 'white' },
      { id: 4, imgName: 'sevenWonders/4.png', my: 0, your: 0, bColor: '#ebff82', bhColor: 'white' },
      { id: 5, imgName: 'sevenWonders/5.png', my: 0, your: 0, bColor: '#8977ad', bhColor: 'white' },
      { id: 6, imgName: 'sevenWonders/6.png', my: 0, your: 0, bColor: '#8977ad', bhColor: 'white' },
      { id: 7, imgName: 'sevenWonders/7.png', my: 0, your: 0, bColor: 'lightgreen', bhColor: 'white' },
      { id: 8, imgName: 'sevenWonders/8.png', my: 0, your: 0, bColor: '#ebff82', bhColor: 'white' },
      { id: 9, imgName: 'sevenWonders/9.png', my: 0, your: 0, bColor: '#F05650', bhColor: 'white' },
      { id: 10, imgName: 'sevenWonders/10.png', bColor: 'white', bhColor: 'white', isSum: true, },
      { id: 11, imgName: 'sevenWonders/11.png', my: false, your: false, bColor: 'red', bhColor: 'white', isCheck: true, },
      { id: 12, imgName: 'sevenWonders/12.png', my: false, your: false, bColor: 'green', bhColor: 'white', isCheck: true, },
    ]);

    const updateValue = (value) => {
      console.debug('updateValue', value);

      const targetItem = _.find(data.value, item => item.id === value.id);
      targetItem[value.target] = Number(value.value);
    }

    const onClickRow = (value) => {
      connection.send('rowClick');
      console.log(value, 'onClickRow');
    }

    const templateUrl = 'sevenWonders/row'
    return {
      templateUrl,
      data,
      updateValue,
      onClickRow
    }

  },
}
</script>
<style scoped lang="scss">
  div {
    &.sw-div {
      overflow: auto;
    }
  }
</style>