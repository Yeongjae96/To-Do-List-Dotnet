<template>
  <div>
    안녕하세요 꼬릿글입니다.    
  </div>
</template>
<script>
import { reactive } from 'vue' 
export default {
  setup(props) {

    var rProps = reactive(props);

    console.log(11, rProps);
  }
}
</script>
