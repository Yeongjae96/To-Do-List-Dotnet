<template>
  <font-awesome-icon :icon="['fas', name]" :size="size"/>
</template>

<script>
export default {
  name: 'y-icon',
  props: {
    name: {
      type: String,
      default: '제목을 입력해주세요',
    },
    size: {
      type: String,
      default: 'sm',
    },
  },
  data() {
    return {
      style: {},  
    };
  },
  computed: {
  },
  mounted() {
  },
  methods: {
  }
}
</script>
<style scoped>
  
</style>