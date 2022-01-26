<template>
  <div class="wrapper">
    <slot></slot>
  </div>
</template>

<script>
export default {
  name: 'y-always-scrollbar',

}
</script>

<style lang="scss" scoped>
  .wrapper {
    width: 100%;
    height: 100%;
    overflow: scroll;

    &::-webkit-scrollbar {
      width: 8px;
      height: 8px;
      border-radius: 6px;
      background: rgba(255, 255, 255, 0.4);
    }
    &::-webkit-scrollbar-thumb {
      background-color: rgba(0,0,0,0.3);
      border-radius: 6px;
    }
  }
</style>